#include <iostream>
#include <vector>
#include <ctime>

void shakeSort(int arr[], int arrLength) {
	int* left = arr;
	int* right = arr + arrLength - 1;

	do {
		for (int* i = left; i < right; i++) {
			if (*i > *(i + 1)) {
				int tmpSwapper = *i;
				*i = *(i + 1);
				*(i + 1) = tmpSwapper;
			}
		}

		right--;

		for (int* i = right; i > left; i--) {
			if (*i < *(i - 1)) {
				int tmpSwapper = *i;
				*i = *(i - 1);
				*(i - 1) = tmpSwapper;
			}
		}

		left++;

	} while (left < right);
}

void fillArr(int arr[], int arrLength) {
	for (int i = 0; i < arrLength; i++) {
		arr[i] = (rand() % 100);
	}
}

void printArr(int arr[], int arrLength) {
	for (int i = 0; i < arrLength; i++) {
		printf("%d\n", arr[i]);
	}
	printf("-|-|-\n");
}

int main()
{
	const int ArrLength = 15;
	int mainArr[ArrLength];
	
	fillArr(mainArr, ArrLength);

	printArr(mainArr, ArrLength);

	shakeSort(mainArr, ArrLength);

	printArr(mainArr, ArrLength);
}