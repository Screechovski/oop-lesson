#include <iostream>
#include <string>
#include <ctime>

using namespace std;

struct student {
	int exam1;
	int exam2;
	int exam3;
};

int main()
{
	const int studentsCount = 10;
	string optionFillingArray = "";
	struct student studentsArray[studentsCount];

	double sum1 = 0.0;
	double sum2 = 0.0;
	double sum3 = 0.0;

	std::cout << "Set enter type: (1:'auto' 2:'console'): ";
	std::cin >> optionFillingArray;

	if (optionFillingArray == "1") {
		srand(time(0));

		for (int i = 0; i < studentsCount; i++) {
			int rnd1 = rand() % 4 + 2;
			int rnd2 = rand() % 4 + 2;
			int rnd3 = rand() % 4 + 2;

			studentsArray[i].exam1 = rnd1;
			studentsArray[i].exam2 = rnd2;
			studentsArray[i].exam3 = rnd3;
			std::cout << rnd1 << " " <<  rnd2 << " " << rnd3 << "\n";
		}
	}
	else if (optionFillingArray == "2") {
		for (int i = 0; i < studentsCount; i++) {
			std::cout << "Enter mark between 2,5 for " << i + 1 << " student\n";
			std::cin >> studentsArray[i].exam1;
			std::cin >> studentsArray[i].exam2;
			std::cin >> studentsArray[i].exam3;
		}
	}

	for (int i = 0; i < studentsCount; i++) {
		sum1 += studentsArray[i].exam1;
		sum2 += studentsArray[i].exam2;
		sum3 += studentsArray[i].exam3;
	}

	sum1 = sum1 / studentsCount;
	sum2 = sum2 / studentsCount;
	sum3 = sum3 / studentsCount;

	std::cout << "avg mark exam1 " << sum1 << "\n";
	std::cout << "avg mark exam2 " << sum2 << "\n";
	std::cout << "avg mark exam3 " << sum3 << "\n";
	system("pause");
	return 0;
}