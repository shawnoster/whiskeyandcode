---
title: A Simple Delphi rakefile
date: '2007-08-16T12:15:00Z'
draft: true
---

Building projects has always been a pain in the arse. You want it to be simple, fast and easily reproducible, all of which are tenets of good continuous integration. When it comes to building a Delphi project I've tried a whole slew of things from batch files to the Ant-based Want to very slick IDE's like Automated Build Studio and FinalBuilder. I keep coming back to simple DOS-based apps though because in my ideal world a user should be able to do a clean checkout of your code and then be able to build.

Currently I use Want, which is a Delphi port of Java's Ant, .NET users will probably think of NAnt which was also a port and then heavily extended. Ant, or it's derivatives, is great until you need to manage a large build file and have to wade though all that xml to figure out what's going on. Xml is just not the best format for humans to muck about in so lately I've been looking at Rake, basically Ruby's version of make. Maybe I'll whip this up into an tutorial or something more informative but for now here is a *very* basic build script using rake, in fact it's the one I use to build my ZuneKeys application:

```ruby
def compile_project(project_file)     
   args = "-B -Q #{project_file}";  
   result = %x[dcc32 #{args}]  
   if result =~ /Error/  
       puts result     
   else  
       project_name = project_file.gsub(/..*/, "")  
       puts "built #{project_name}"  
   end  
end
```

```ruby
file 'ZuneKeys.exe' => ['ZuneKeys.dpr', FileList['*.pas']] do  
   compile_project "ZuneKeys.dpr"  
end
```

```ruby
task :default => ['ZuneKeys.exe'] do         
end
```

```ruby
desc "Remove temporary files created during compile"  
task :clean do     
   if File.exists?('ZuneKeys.exe')   
       rm "ZuneKeys.exe"  
   end  
   rm FileList['*.dcu']  
   puts "clean"  
end
```

```ruby
task :release => [:clean, :default] do  
   puts "release project"  
end
```
