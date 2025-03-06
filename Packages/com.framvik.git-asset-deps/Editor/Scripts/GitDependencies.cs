using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Framvik.GitAssets.Dependencies
{
    /// <summary>
    /// Container for defining git URLs as package dependencies.
    /// </summary>
    [CreateAssetMenu(fileName = "GitDeps", menuName = "Git Asset/Create Git Dependency File", order = 250)]
    public class GitDependencies : ScriptableObject, IEnumerable<string>
    {
        public string[] GitURLs;
        public int Count => GitURLs.Length;
        public string this[int i] { get { return GitURLs[i]; } }
        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>)GitURLs).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GitURLs.GetEnumerator();
        }

        /// <summary>
        /// Finds and returns all GitDependencies assets in the project. This will find in loaded packages as well.
        /// </summary>
        public static GitDependencies[] FindAllDependencies()
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(GitDependencies).Name);
            GitDependencies[] a = new GitDependencies[guids.Length];
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<GitDependencies>(path);
            }
            return a;
        }
    }
}

