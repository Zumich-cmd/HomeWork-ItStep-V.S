#ifndef CLASSES_H
#define CLASSES_H

#include <iostream>
using namespace std;

template <class T1, class T2>
class base {
protected:
    T1 value1;
    T2 value2;

public:
    base() {
        value1 = 0;
        value2 = 0;
    }

    base(T1 v1, T2 v2) {
        value1 = v1;
        value2 = v2;
    }

    void setValue1(T1 v1) { value1 = v1; }
    void setValue2(T2 v2) { value2 = v2; }

    T1 getValue1() const { return value1; }
    T2 getValue2() const { return value2; }
};

template <class T1, class T2>
class derived1 : virtual public base<T1, T2> {
protected:
    T1 value3;

public:
    derived1() {
        value3 = 0;
    }

    derived1(T1 v1, T2 v2, T1 v3) : base<T1, T2>(v1, v2) {
        value3 = v3;
    }

    void setValue3(T1 v3) { value3 = v3; }
    T1 getValue3() const { return value3; }
};

template <class T1, class T2>
class derived2 : virtual public base<T1, T2> {
protected:
    T2 value4;

public:
    derived2() {
        value4 = 0;
    }

    derived2(T1 v1, T2 v2, T2 v4) : base<T1, T2>(v1, v2) {
        value4 = v4;
    }

    void setValue4(T2 v4) { value4 = v4; }
    T2 getValue4() const { return value4; }
};

template <class T1, class T2>
class result : public derived1<T1, T2>, public derived2<T1, T2> {
public:
    result() {}

    result(T1 v1, T2 v2, T1 v3, T2 v4)
        : base<T1, T2>(v1, v2),
        derived1<T1, T2>(v1, v2, v3),
        derived2<T1, T2>(v1, v2, v4) {}

    void show() const {
        cout << "Value1: " << this->value1 << endl;
        cout << "Value2: " << this->value2 << endl;
        cout << "Value3: " << this->value3 << endl;
        cout << "Value4: " << this->value4 << endl;
    }
};

#endif