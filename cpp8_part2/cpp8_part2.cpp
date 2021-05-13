#include <iostream>

char* F11(char* c, int& m) {
    char* b = NULL;

    for (m = 0; *c != 0; c++) {
        if (*c == c[1]) {
            for (int k = 2; *c == c[k]; k++) {
                if (k > m) m = k, b = c;
            }
        }
    }
    return b;
}

int main() {
    int num = 15;
    int* numLink = &num;

    char letters[] = "aasdasd";

    char letter = 'a';

    char* letterLink = letters;

    printf(F11(&letter, num));
}