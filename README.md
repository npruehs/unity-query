# UnityQuery

UnityQuery is a small, lightweight C# library designed to increase productivity with [Unity3D](http://unity3d.com/).

Each and every one of us has written these small utility and extension methods we're using and re-writing over and over again with each new project. UnityQuery aims to collect the most general, versatile and helpful of these code snippets for re-use, and is inspired by recent work at the [Slash Framework](http://www.slashgames.org/framework) and by [LINQ to GameObject](https://github.com/neuecc/LINQ-to-GameObject-for-Unity) by Yoshifumi Kawai.

If you're missing any of your personal favorites, we'd love to see it - please refer to the [Contributing](https://github.com/npruehs/unity-query/blob/master/CONTRIBUTING.md) file!

## Features

* Hierarchy queries (e.g. GetChildren, GetDescendants, OnLayer, IsAncestor, GetRoot, ...)
* Hierarchy manipulation (e.g. DestroyChildren)
* Component-wise vector swizzling (e.g. v.XZ)
* Changing single vector or color components while preserving immutability
* Picking (e.g. object at mouse position)
* Collection extensions (e.g. ContainsAll, GetValueOrDefault, IsNullOrEmpty, SequenceToString)
* Logs with timestamps and object names

## Getting UnityQuery

You can either

* download the latest [Unity package](https://github.com/npruehs/unity-query/releases), or
* checkout the repository (requires [Unity Test Tools](https://www.assetstore.unity3d.com/en/#!/content/13802))

Later releases will be available at the Asset Store as well.

## Usage

Just import the `UnityQuery` namespace and you're good to go!

    using UnityQuery;

Right now, all of the UnityQuery methods are implemented as extension methods.

    Vector3 u = new Vector3(1, 2, 3);
    Vector2 v = u.XY();
	
That means, you can use all of them as syntatic sugar without having to recall where they're located.

    var o = Camera.main.PickObject();

Note there's also a [Cheat Sheet](https://github.com/npruehs/unity-query/raw/master/Source/UnityQuery/Assets/UnityQuery/UnityQuery%20Cheat%20Sheet.pdf) available for you.

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

## Contributors

(in no particular order)

* [Nick Prühs](https://github.com/npruehs) (Maintainer)
* [Christian Oeing](https://github.com/coeing)
* [Björn von der Osten](https://github.com/Froghut)
* [Patrick Henschel](https://bitbucket.org/Ffyhlkain)
* Michael Kluge
* [Johannes Deml](https://github.com/JohannesDeml)

## License

UnityQuery is released under the [MIT license](https://github.com/npruehs/unity-query/blob/master/LICENSE).
