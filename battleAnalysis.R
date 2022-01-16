library(readxl)
library(ggplot2)
library(dplyr)
library(proxyC)

combatlog <- read_excel("Documents/VSCode/battle/combatlog.xlsx")
View(combatlog)

head(combatlog)
dim(combatlog)

hist(combatlog$PlayerAttack1, main = "Player Weapon")

ggplot(combatlog, aes(x=PlayerAttack1, y=EnemyAttack1))+geom_point()

# This graph is expected, since it shows every weapon damage including misses
# overlapping with all different values of weapon damage.

# Now need to create a new data column that tells us who won that combat encounter.
# This would be trivial to do in the actual C# program, but I want to utilize R in
# order to accomplish the same thing.

x <- rep("Player",1000)
WinnerFrame <- data.frame("Winner"=x)
playerCols <- c(3,5,7,9,11,13,15,17,19,21)

for (i in 1:nrow(combatlog)) {
  Row <- combatlog[i,]
  firstNA <- match("NA",as.character(Row))
  if (firstNA %in% playerCols) {
    WinnerFrame[i,] = "Enemy"
  }
}

combatlog$Winner <- WinnerFrame

# For loop takes each row and finds the first "NA" value (which is always in the
# column of the defeated, since they didn't have a chance to make their next attack).
# Loop then checks to see if this NA is in a player column. If it is, it sets the 
# winner as the enemy. Otherwise, player winning is the default.

combatlog$Winner <- unlist(combatlog$Winner)
ggplot(combatlog, aes(x=Winner, y=PlayerAttack1))+geom_point()

PlayerWins <- filter(combatlog, Winner == "Player")
EnemyWins <- filter(combatlog, Winner == "Enemy")

# Just from splitting the data between who wins the encounter, we can see the 
# advantage the player going first gives. The player won 611 out of 1000 combats,
# while the enemy only won 389.

colMeans(PlayerWins[3:21], na.rm = TRUE)
colMeans(EnemyWins[3:21], na.rm = TRUE)

# The average damage inflicted on the first hit by the player when the player wins
# is 5.20. The average damage on the first hit by the player when the player loses
# is 3.16. The stats for the enemy's first attack are similar.

sum(PlayerWins$PlayerAttack1 == 0)
sum(EnemyWins$PlayerAttack1 == 0)
sum(PlayerWins$EnemyAttack1 == 0)
sum(EnemyWins$EnemyAttack1 == 0)

# We would expect to see more total misses in losses from both player and enemy.
# The enemy did miss more in losses, but unexpectedly, the player missed more
# in wins. This could be more evidence of how powerful going first is, that early misses
# do not seem to punish the player much at all.