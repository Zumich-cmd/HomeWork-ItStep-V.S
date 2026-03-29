#include "classes.h"

int main() {
    result<int, double> obj(10, 5.5, 20, 7.7);

    cout << "Initial values:" << endl;
    obj.show();

    cout << endl;

    obj.setValue1(100);
    obj.setValue2(25.5);
    obj.setValue3(300);
    obj.setValue4(45.8);

    cout << "Changed values:" << endl;
    obj.show();

    return 0;
}