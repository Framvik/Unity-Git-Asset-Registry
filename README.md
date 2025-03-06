# Unity Git Asset Registry

![](https://img.shields.io/github/stars/Framvik/Unity-Git-Asset-Registry) ![](https://img.shields.io/github/forks/Framvik/Unity-Git-Asset-Registry) ![](https://img.shields.io/github/release/Framvik/Unity-Git-Asset-Registry) ![](https://img.shields.io/github/issues/Framvik/Unity-Git-Asset-Registry)

Implements a local registry for managing project assets and packages from git inside the Unity editor. This project is separated into different packages depending on the need for your project.

## Features
- Simple menu for managing custom collection of packages and assets hosted as git repositories.
- Simple ways to toggle/add/remove packages when working with large, isolated groups of assets.
- Automatic solving of git dependencies inside packages.

## Installing The Packages

Simply add one of the following package URLs using the menu inside the Package Manager menu `+ > Add package from git URL`.

### Git Asset Registry
```
https://github.com/Framvik/Unity-Engine-Tools.git?path=/Packages/com.framvik.git-asset-registry
```
Define your custom git asset collections and manage them with a simple menu.

#### Instructions
TODO

### Git Asset Editor
```
https://github.com/Framvik/Unity-Engine-Tools.git?path=/Packages/com.framvik.git-asset-editor
```
Editor tools for collecting unity packages on git into embedded packages.

#### Instructions
TODO

### Git Asset Dependencies
```
https://github.com/Framvik/Unity-Engine-Tools.git?path=/Packages/com.framvik.git-asset-deps
```
A simple way to automatically solve git package dependencies.

#### Instructions
Create a `GitDeps.asset` file by using the `Git Asset` menus. Inside you can enter multiple url for git repositories that contains packages. Whenever the editor updates packages we will automatically check and adjust packages using git sources to follow all defined `GitDeps.asset` files.

#### `Create -> Git Asset -> Create Git Asset Dependency File`
Creates an empty GitDeps file at given project location.

#### `Assets -> Git Asset -> Generate Git Asset Dependency File`<br>
Checks the project manifest for git sourced packages and generates a GitDeps file not referenced in other GitDeps files.

### `Assets > Git Asset > Refresh Git Asset Dependencies`
Manually refresh the git package dependencies.