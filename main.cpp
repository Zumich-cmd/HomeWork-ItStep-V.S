#include "classes.h"

int main() {
    Equation* eq1 = new LinearEquation(2, -4);
    Equation* eq2 = new QuadraticEquation(1, -5, 6);

    cout << "Task 1" << endl;
    eq1->findRoots();

    cout << endl;

    eq2->findRoots();

    delete eq1;
    delete eq2;
}