# FAQ

## Why are there no helper methods for handling [Coroutines](http://docs.unity3d.com/Manual/Coroutines.html)?

Yes, we agree: Coroutines are ugly. Fortunately, there is already a very nice open-source solution to this problem called [Reactive Extensions for Unity](https://github.com/neuecc/UniRx) by Yoshifumi Kawai.

Reactive Extensions for Unity provide asynchronous operations with return values and proper error handling, and we don't think we could do that any better.

## Why are there no helper methods for creating and accessing [Singletons](https://en.wikipedia.org/wiki/Singleton_pattern)?

UnityQuery aims to be a lightweight library, not a framework: We want to provide utility methods without imposing structure on your project.

This implies that you shouldn't need to create types deriving from UnityQuery types in order to use the library. If you want to implement parts of your game as singletons, roll your own or check [other implementations such as the one in the Unify Community Wiki](http://wiki.unity3d.com/index.php/Toolbox).
