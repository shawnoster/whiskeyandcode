+++
title = "Running a .NET 2.0 App from a Network Share"
date = "2007-07-07T09:23:00Z"
categories = ["Code"]
tags = [".NET"]
draft = false
+++

Just ran into an issue trying to run a simple .NET 2.0 file writing command-line app across a network share. No matter how much beating we couldn't get it to run until we ran across this little batch file in the comments on the .NET Security Blog post, [Using CasPol to Fully Trust a Share](http://blogs.msdn.com/shawnfa/archive/2004/12/30/344554.aspx):

```powershell
call %windir%Microsoft.NETFrameworkv2.0.50727caspol -q -m -ag 1.2 -url %1* FullTrust -n %1 -d "FullTrust granted to:  %1"
```

I dropped the code into a batch file called `trustshare.bat` and ran it like this:

```powershell
trustshare.bat //machine/sharename
```

Suddenly the three hours of hair pulling finally ended. The batch file needs to be run on each machine that's attempting to run the application, not on the machine that's actually sharing the application.

While I really enjoy .NET for web applications I go crazy trying to use them as stand-alone desktop apps. I much prefer CodeGear's Delphi when creating standard Win32 apps, you get a single EXE and don't have to worry about a secondary layer of security permissions beyond the file system during deployment.
