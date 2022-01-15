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

## Simple queries

Read the word-list included in submodule `english-words` (from [dwyl/english-words](https://github.com/dwyl/english-words)):

```powershell
Read-Words -Path ./english-words/words_alpha.txt
```

Read the word-list, and filter to all words of length `4`:

```powershell
Read-Words -Path ./english-words/words_alpha.txt | Limit-Words -Length 4
```

Read the word-list, and filter to all words containing `love`:

```powershell
Read-Words -Path ./english-words/words_alpha.txt | Limit-Words -Contains love
```

Read the word-list, and filter to all words matching crossword rule `z??c`:

```powershell
Read-Words -Path ./english-words/words_alpha.txt | Limit-Words -Crossword z??c
```

Read the word-list, and filter to all words matching [regular expression](https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference) `^[ab][ab].+d$`:

```powershell
Read-Words -Path ./english-words/words_alpha.txt | Limit-Words -Regex ^[ab][ab].+d$
```

Read the word-list, and filter to the word matching simple anagram `rcleve`:

```powershell
Read-Words -Path ./english-words/words_alpha.txt | Limit-Words -Anagram rcleve
```


Read the word-list, and filter to the word matching partial anagram `rcleve?`:

```powershell
Read-Words -Path ./english-words/words_alpha.txt | Limit-Words -Anagram rclev?
```

Read the word-list, filter to the word matching partial anagram `rcleve?`, and filter again to those matching crossword rule `?love?`:

```powershell
Read-Words -Path ./english-words/words_alpha.txt | Limit-Words -Anagram rclev? | Limit-Words -Crossword ?love?
```

🍀
