# AnagramExperiment
[![Build status](https://ci.appveyor.com/api/projects/status/h67ynlk4ooykhvj2/branch/master?svg=true)](https://ci.appveyor.com/project/feldrim/AnagramExperiment?branch=master)
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Ffeldrim%2FAnagramExperiment.svg?type=shield)](https://app.fossa.io/projects/git%2Bgithub.com%2Ffeldrim%2FAnagramExperiment?ref=badge_shield)

## Motivation
This repository is solely intended to solve [a problem by Helmes](https://testyourself.helmes.ee/), which I've come across through an Instagram ad by [Work in Estonia](https://www.workinestonia.com/).

## Problem
As descibed by Helmes, the problem is to write a program wich takes two inputs: 
1. The path of a word list
2. The word

The output of the program is the anagrams of the given word in the word list including the time for operations.

## Methodology
* I've used TDD for designing the application, which helped me create "the most" simple, working and readable architecture and code.
* I've used a local git repository because I was on a weekend trip where I had limited access to internet, then pushed it to Github.

## Approach
I've used a unique dictionary which takes each letter of a given word, sort them in alphabetical order and make a word out of it as a key. For the values, it contains all the words made of the letters given in the key -which is literally the anagrams. I've used ConcurrentDictionary for better performance. 

## Building
The repository contains two projects:
1. Console application project
2. Test project

It's written in C# with Visual Studio IDE. So all you need to build the solution is open the AnagramExperiment.sln file on a Visual Studio IDE.

I've used only Resharper for unit testing. It's a simple project and contains only tests for design. No tests for validation of inputs or other purposes involved on purpose.

## TO-DO
* The need for other tests will be considered.
* ~~Input validation will be added.~~
* ~~Performance improvements (if possible)~~


## License
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Ffeldrim%2FAnagramExperiment.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2Ffeldrim%2FAnagramExperiment?ref=badge_large)
