using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;

namespace Framvik.GitAssets.Dependencies
{
    /// <summary>
    /// Container for a git sourced PackageInfo.packageId separated into package name and git url.
    /// </summary>
    public struct GitPackageId
    {
        public string Id;
        public string URL;

        /// <summary>
        /// Get an GitPackageId array of all loaded Packages that have git source.
        /// </summary>
        public static GitPackageId[] GetLoadedGitPackages()
        {
            var existingGitUrl = new HashSet<string>();
            var packages = new List<GitPackageId>();
            foreach (var package in PackageInfo.GetAllRegisteredPackages())
            {
                try
                {
                    if (package.source == PackageSource.Git)
                    {
                        var split = package.packageId.Split('@');
                        if (existingGitUrl.Add(split[1]))
                            packages.Add(new GitPackageId { Id = split[0], URL = split[1] });
                    }
                }
                catch (Exception) { }
            }
            return packages.ToArray();
        }

        /// <summary>
        /// Get an array of all git url inside the loaded Packages.
        /// </summary>
        public static string[] GetLoadedGitUrl()
        {
            var existingGitUrl = new HashSet<string>();
            foreach (var package in PackageInfo.GetAllRegisteredPackages())
            {
                try
                {
                    if (package.source == PackageSource.Git)
                        existingGitUrl.Add(package.packageId.Split('@')[1]);
                }
                catch (Exception) { }
            }
            return existingGitUrl.ToArray();
        }
    }
}