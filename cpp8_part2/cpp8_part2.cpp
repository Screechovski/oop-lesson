#include <iostream>

void F15(char* c) {
    for (char* p = c; *p != '\0'; p++) {
        for (p--; p > c; p--, c++)
        {
            char s; s = *p; *p = *c; *c = s;
        }
    }
}

int main() {

    char letter = 'd';

    std::cout << letter << std::endl;
    std::cout << &letter << std::endl;

    F15(&letter);

    std::cout << letter << std::endl;
    std::cout << &letter << std::endl;

    return 0;
}