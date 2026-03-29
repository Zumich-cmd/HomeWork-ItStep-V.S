#ifndef CLASSES_H
#define CLASSES_H

#include <iostream>
#include <fstream>
#include <cmath>
#include <new>
using namespace std;

class MyException {
protected:
    const char* message;

public:
    MyException(const char* msg) {
        message = msg;
    }

    virtual void show() const {
        cout << "Exception: " << message << endl;
    }

    virtual ~MyException() {
    }
};

class MathException : public MyException {
public:
    MathException(const char* msg) : MyException(msg) {
    }

    void show() const override {
        cout << "Math exception: " << message << endl;
    }
};

class DivisionByZeroException : public MathException {
public:
    DivisionByZeroException() : MathException("division by zero") {
    }
};

class NegativeRootException : public MathException {
public:
    NegativeRootException() : MathException("square root from negative number") {
    }
};

class MemoryException : public MyException {
public:
    MemoryException() : MyException("memory allocation error") {
    }

    void show() const override {
        cout << "Memory exception: " << message << endl;
    }
};

class FileException : public MyException {
public:
    FileException(const char* msg) : MyException(msg) {
    }

    void show() const override {
        cout << "File exception: " << message << endl;
    }
};

class FileOpenException : public FileException {
public:
    FileOpenException() : FileException("cannot open file") {
    }
};

double divide(double a, double b) {
    if (b == 0) {
        throw DivisionByZeroException();
    }
    return a / b;
}

double squareRoot(double x) {
    if (x < 0) {
        throw NegativeRootException();
    }
    return sqrt(x);
}

void checkMemory() {
    try {
        int size;
        cout << "Enter size of dynamic array: ";
        cin >> size;

        if (size <= 0) {
            throw MemoryException();
        }

        int* arr = new int[size];
        delete[] arr;
    }
    catch (bad_alloc&) {
        throw MemoryException();
    }
}

void checkFile() {
    ifstream file("test.txt");

    if (!file.is_open()) {
        throw FileOpenException();
    }

    file.close();
}

#endif