Create a `GitDeps.asset` file by using the `Git Asset` menus. Inside you can enter multiple url for git repositories that contains packages. Whenever the editor updates packages we will automatically check and adjust packages using git sources to follow all defined `GitDeps.asset` files.

`Create -> Git Asset -> Create Git Asset Dependency File`
Creates an empty GitDeps file at given project location.

`Assets -> Git Asset -> Generate Git Asset Dependency File`<br>
Checks the project manifest for git sourced packages and generates a GitDeps file not referenced in other GitDeps files.

`Assets > Git Asset > Refresh Git Asset Dependencies`
Manually refresh the git package dependencies.

Other project information and documentation can be found at:
`<link>`: <(https://github.com/Framvik/Unity-Git-Asset-Registry)>