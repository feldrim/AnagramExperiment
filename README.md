# AnagramExperiment

## Motivation
This repository is solely intended to solve [a problem by Helmes](https://testyourself.helmes.ee/), which I've came across through an Instagram ad of [Work in Estonia](https://www.workinestonia.com/).

## Problem
As descibed by Helmes, the problem is to write a program wich takes two inputs: 
1. The path of a word list to parse and look up
2. The word to look up anagrams in the given word list

## Methodology
* I've used TDD for designing the application, which helped me create "the most" simple, working and readable architecture and code.
* I've used a local git repository because I was on a weekend trip where I had limited access to internet, then pushed it to Github.

## Approach
I've used a unique dictionary which takes each letter of a given word, sort them in alphabetical order and make a word out of it as a key. For the values, it contains all the words made of the letters given in the key -which is literally the anagrams.

## Building
The repository contains two projects:
1. Console application project
2. Test project

It's written in C# with Visual Studio IDE. So all you need to build the solution is open the AnagramExperiment.sln file on a Visual Studio IDE.

I've used only Resharpe for unit testing. It's a simple project and contains only tests for design. No tests for validation of inputs or other purposes involved on purpose.

## TO-DO
* TestInitialize method was modified to check if it can read the text file and converted to the anagram dictionary. The mock AnagramDictionary object shall be created as it was before.
* The need for other tests will be considered.
* Input validation will be added.
