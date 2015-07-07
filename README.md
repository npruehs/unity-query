# UnityQuery

UnityQuery is a fast, small, lightweight C# library designed to increase productivity with [Unity3D](http://unity3d.com/).

Each and every one of us has written these small utility and extension methods we're using and re-writing over and over again with each new project. UnityQuery aims to collect the most general, versatile and helpful of these code snippets for re-use.

If you're missing any of your personal favotites, we'd love to see it - please refer to the Contributing section below!

## Features

* Component-wise vector swizzling (e.g. v.XZ)
* Hierarchy queries (e.g. GetChildren, GetDescendants, IsAncestor, ...)
* Hierarchy manipulation (e.g. DestroyChildren)
* Collection extensions (e.g. ContainsAll, GetValueOrDefault, IsNullOrEmpty, SequenceToString)

## Development Cycle

We know that using a library like UnityQuery in production requires you to be completely sure about stability and compatibility. Thus, new releases of UnityQuery are created using [Semantic Versioning](http://semver.org/). In short:

* Version numbers are specified as MAJOR.MINOR.PATCH.
* MAJOR version increases indicate incompatible changes with respect to the public UnityQuery API.
* MINOR version increases indicate new functionality that are backwards-compatible.
* PATCH version increases indicate backwards-compatible bug fixes.

## Bugs & Feature Requests

We are sorry that you've experienced issues or are missing a feature! After verifying that you are using the [latest version](https://github.com/npruehs/unity-query/releases) of UnityQuery and having checked whether a [similar issue](https://github.com/npruehs/unity-query/issues) has already been reported, feel free to [open a new issue](https://github.com/npruehs/unity-query/issues/new). In order to help us resolving your problem as fast as possible, please include the following details in your report:

* Steps to reproduce
* What happened?
* What did you expect to happen?

After being able to reproduce the issue, we'll look into fixing it immediately.

## Contributing

You'd like to help make UnityQuery even more awesome? Seems like today's our lucky day! In order to maintain stability of the tool and its code base, please adhere to the following steps, and we'll be pleased to include your additions in our next release.

Note that UnityQuery is distributed under the [MIT License](https://github.com/npruehs/unity-query/blob/master/LICENSE). So will be your code.

### Step 1: Choose what to do

If you've got no idea how to help, head over to our [issue tracker](https://github.com/npruehs/unity-query/issues) and see what you'd like to do most. You can basically pick anything you want to, as long as it's not already assigned to anyone.

If you know exactly what you're missing, [open a new issue](https://github.com/npruehs/unity-query/issues/new) to begin a short discussion about your idea and how it fits the project. If we all agree, you're good to go!

### Step 2: Fork the project and check out the code

UnityQuery is developed using the [GitFlow branching model](http://nvie.com/posts/a-successful-git-branching-model/). In order to contribute, you should check out the latest develop branch, and create a new feature or hotfix branch to be merged back.

### Step 3: Implement your feature or bugfix

We recommend using [StyleCop](http://stylecop.codeplex.com/) for verifying your code against our [coding guidelines](https://msdn.microsoft.com/en-us/library/ff926074.aspx).

### Step 4: Open a pull request

Finally, [open a pull request](https://help.github.com/articles/using-pull-requests/) so we can review your changes together, and finally integrate it into the next release.

## License

UnityQuery is released under the [MIT license](https://github.com/npruehs/unity-query/blob/master/LICENSE).
