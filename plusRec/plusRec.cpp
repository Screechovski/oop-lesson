#include <iostream>

/*Ежедневно Незнайка учит половину от суммы выученных за два предыдущих дня иностранных слов и еще два слова.
Знайка считает, что силы Незнаики иссякнут, когда нужно будет
выучить 50 слов в день.Написать программу, определяющую, через сколько дней иссякнут силы у Незнайки, если в первые два дня
он выучил по одному слову.*/

int countingPeviousWords(int prevWords, int prevPrevWords, int days) {
    std::cout << prevWords << " " << prevPrevWords << " " << days << "\n";
    int currentDayWords = ceil((prevWords + prevPrevWords) / 2 + 2);
    if (currentDayWords >= 50) {
        return days;
    }
    return countingPeviousWords(currentDayWords, prevWords, days + 1);
}

int main()
{
    int wordsCountPrev = 1;
    int wordsCountPrevPrev = 1;
    int dayCount = 3;

    std::cout << countingPeviousWords(wordsCountPrev, wordsCountPrevPrev, dayCount);
}