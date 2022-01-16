# word-tools

PowerShell tools for puzzle solving.

## Prerequisites (OS X)

Install [PowerShell](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-macos?view=powershell-7.2). This can be done easily with [Homebrew](https://brew.sh/) package manager on OS X:

```bash
brew install --cask powershell
```

This repository contains an English words list as submodule `english-words`. Either clone this repository, or clone [dwyl/english-words](https://github.com/dwyl/english-words) directly:

```bash
git clone https://github.com/instantiator/word-tools.git
git clone https://github.com/dwyl/english-words.git
```

Download the module `WordToolsCmdlet.dll` from the latest release:

* [Latest release](https://github.com/instantiator/word-tools/releases/latest)

Start PowerShell:

```bash
$ pwsh
```

Import the module into PowerShell:

```powershell
Import-Module ./WordToolsCmdlet.dll
```

## Simple queries: filtering word lists

**NB.** Parameter names are not case sensitive, eg. `-WordList` and `-wordlist` are equivalent.

```powershell
Import-Words -WordListPath ./english-words/words_alpha.txt -WordList 'extrawords','gohere'
```

```text
Text
----
aardvark
...
extrawords
gohere
```

```powershell
Import-Words -WordList 'one','two','three' | Join-Words
```

```text
Words
-----
{one, three, two}
{one, two, three}
{three, one, two}
{three, two, one}
{two, one, three}
{two, three, one}
```

```powershell
Import-Words -WordListPath ./english-words/words_alpha.txt | Select-Words -length 4
```

```text
Text
----
...
zuni
zuza
```

```powershell
Import-Words -WordListPath ./english-words/words_alpha.txt | Select-Words -crossword ?love?
```

```text
Text
----
cloven
clover
cloves
gloved
glovey
glover
gloves
plover
sloven
```

```powershell
Import-Words -WordListPath ./english-words/words_alpha.txt | Select-Words -regex ^[cp]love.$
```

```text
Text
----
cloven
clover
cloves
plover
```

```powershell
Import-Words -WordListPath ./english-words/words_alpha.txt | Select-Words -length 6 | Select-Words -contains lover
```

```text
Text
----
clover
glover
lovery
lovers
plover
```

```powershell
Import-Words -WordListPath ./english-words/words_alpha.txt | Select-Words -anagram ?rclev
```

```text
Text
----
calver
carvel
claver
clever
cliver
clover
culver
curvle
velcro
```

```powershell
Import-Words -WordListPath ./english-words/words_alpha.txt | Select-Words -anagram ?rclev | Select-Words -crossword ?love?
```

```text
Text
----
clover
```

```powershell
Import-Words -WordListPath ./english-words/words_alpha.txt | Select-Words -length 5 -palindrome $true
```

```text
Text
----
...
tenet
tipit
ululu
```

```powershell
Import-Words -WordList 'some','nice','words' | Select-Words -WordList 'nice','words'
```

```text
Text
----
nice
words
```

```powershell
Import-Words -WordList 'dbu' | Unprotect-Ciphertext -Algorithm caesar -WordListPath ./english-words/words_alpha.txt
```

```text
Options    Text
-------    ----
caesar(19) wun
caesar(25) cat
```

```powershell
Import-Words -WordList 'dbu' | Unprotect-Ciphertext -Algorithm caesar -WordListPath ./english-words/words_alpha.txt -Key 25
```

```text
Options    Text
-------    ----
caesar(25) cat
```

Good luck! 🍀

## TODOs

- [ ] Add support for filtering phrases in the same way words are currently filtered.
- [ ] Add support for initials.
- [ ] Add some more interesting word manipulations.
- [ ] Add support for a number of interesting ciphers.
- [ ] Rustle up interesting lists - names of things, groups of things, etc.
- [ ] Explore use of [WordNet](https://wordnet.princeton.edu/download/current-version) and include definitions and semantics for cool new filters.
