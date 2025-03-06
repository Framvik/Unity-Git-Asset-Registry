using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.PackageManager;
using System.IO;
using System.Linq;

namespace Framvik.GitAssets.Dependencies
{
    /// <summary>
    /// Registers editor load callbacks and implements basic logic for how to update packages.
    /// </summary>
    public static class GitAssetDependencyEvents
    {
        [InitializeOnLoadMethod]
        private static void InitializeOnLoad()
        {
            Events.registeredPackages += OnRegisteredPackages;
        }

        private static void OnRegisteredPackages(PackageRegistrationEventArgs obj)
        {
            RefreshGitDependencies();
        }

        [MenuItem("Assets/Git Asset/Generate Git Asset Dependency File", false, 250)]
        private static void GenerateBaseGitAssetDependencyFile()
        {
            // exit if git dependency asset already exists in project
            if (File.Exists("Assets/GitDeps.asset"))
                return;

            // collect a list of all the git packages url that is used
            // TODO: handle git url with different release or tags
            var existingGitUrl = new List<string>(GitPackageId.GetLoadedGitUrl());
            // remove the ones found it git dependency files
            foreach (var dep in GitDependencies.FindAllDependencies())
                foreach (var pkg in dep)
                    existingGitUrl.Remove(pkg);
            // the result is git packages that solely this project depends on
            if (existingGitUrl.Count > 0)
            {
                var gitDeps = ScriptableObject.CreateInstance<GitDependencies>();
                gitDeps.GitURLs = existingGitUrl.ToArray();
                AssetDatabase.CreateAsset(gitDeps, "Assets/GitDeps.asset");
            }
        }

        [MenuItem("Assets/Git Asset/Refresh Git Asset Dependencies", false, 250)]
        public static void RefreshGitDependencies()
        {
            // only git packages defined in GitDependencies should be allowed to exist
            var addPackages = new HashSet<string>();
            foreach (var dep in GitDependencies.FindAllDependencies())
                foreach (var pkg in dep)
                    addPackages.Add(pkg);

            // so remove them
            var removePackages = new HashSet<string>();
            foreach (var pkg in GitPackageId.GetLoadedGitPackages())
                if (!addPackages.Contains(pkg.URL))
                    removePackages.Add(pkg.Id);

            // only update if actual changes are needed
            if (removePackages.Count > 0 || addPackages.Count > 0)
                Client.AddAndRemove(
                    addPackages.Count > 0 ? addPackages.ToArray() : null,
                    removePackages.Count > 0 ? removePackages.ToArray() : null);
        }
    }
}