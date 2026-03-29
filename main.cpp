#include "classes.h"

int main() {
    cout << "Task 2" << endl;
    cout << endl;

    try {
        double result = divide(10, 0);
        cout << "Result: " << result << endl;
    }
    catch (MyException& ex) {
        ex.show();
    }

    cout << endl;

    try {
        double result = squareRoot(-25);
        cout << "Result: " << result << endl;
    }
    catch (MyException& ex) {
        ex.show();
    }

    cout << endl;

    try {
        checkMemory();
        cout << "Memory allocated successfully." << endl;
    }
    catch (MyException& ex) {
        ex.show();
    }

    cout << endl;

    try {
        checkFile();
        cout << "File opened successfully." << endl;
    }
    catch (MyException& ex) {
        ex.show();
    }

    return 0;
}