# Battle

This code is a rudimentary tutorial for myself to become familiar with C# code, practice object oriented programming best practices, and to also refamiliarize myself with data analysis using R.

The program allows the user to pick a weapon and battle an enemy who generates a random weapon every encounter. The weapons all have different damage and accuracy modifiers. The dagger does two damage but hits 100% of the time, while the warhammer does 9 damage but only hits 65% of the time, etc. The weapons are not balanced, its almost impossible to win with the dagger for example, but part of the fun will be determining just how unbalanced the weapons are using R and data analysis.

The program returns a line to a file after every runthrough. The line is of the form "HeroWeapon, EnemyWeapon, HeroAttack1, EnemyAttack1, HeroAttack2, ...". At this moment, the program has been modified so that the player also generates a random weapon. This made it much easier to generate 1000 lines of data to be analyzed.
