+++
title = "TortoiseSVN global ignore pattern for Visual Studio and Delphi"
date = "2007-01-05"
categories = ["Code"]
tags = ["VisualStudio", "Delphi"]
draft = false
+++

Seems I'm reinstalling all the time and I commonly forget my global ignore pattern for svn. Here it is for future me:

```
*bin *obj RECYCLER Bin *.user *.suo *.dcu __history ModelSupport_* *.rsm thumbs.db
```

This pattern is useful for Visual Studio and Delphi development, though if you're checking in third-party Delphi components be sure you have the full source, otherwise you may need to pull the *.dcu part of the pattern.
