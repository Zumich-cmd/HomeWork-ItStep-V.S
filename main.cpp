#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

template <class T>
class Matrix {
private:
    int rows;
    int cols;
    T** data;

public:
    Matrix() {
        rows = 0;
        cols = 0;
        data = nullptr;
    }

    Matrix(int r, int c) {
        rows = r;
        cols = c;

        data = new T * [rows];
        for (int i = 0; i < rows; i++) {
            data[i] = new T[cols];
        }
    }

    Matrix(const Matrix& other) {
        rows = other.rows;
        cols = other.cols;

        data = new T * [rows];
        for (int i = 0; i < rows; i++) {
            data[i] = new T[cols];
            for (int j = 0; j < cols; j++) {
                data[i][j] = other.data[i][j];
            }
        }
    }

    Matrix& operator=(const Matrix& other) {
        if (this != &other) {
            clearMemory();

            rows = other.rows;
            cols = other.cols;

            data = new T * [rows];
            for (int i = 0; i < rows; i++) {
                data[i] = new T[cols];
                for (int j = 0; j < cols; j++) {
                    data[i][j] = other.data[i][j];
                }
            }
        }
        return *this;
    }

    ~Matrix() {
        clearMemory();
    }

    void clearMemory() {
        if (data != nullptr) {
            for (int i = 0; i < rows; i++) {
                delete[] data[i];
            }
            delete[] data;
            data = nullptr;
        }
        rows = 0;
        cols = 0;
    }

    void input() {
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                cout << "Enter element [" << i << "][" << j << "]: ";
                cin >> data[i][j];
            }
        }
    }

    void fillRandom() {
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                data[i][j] = rand() % 10 + 1;
            }
        }
    }

    void print() const {
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                cout << data[i][j] << "\t";
            }
            cout << endl;
        }
    }

    T findMin() const {
        T min = data[0][0];

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (data[i][j] < min) {
                    min = data[i][j];
                }
            }
        }

        return min;
    }

    T findMax() const {
        T max = data[0][0];

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (data[i][j] > max) {
                    max = data[i][j];
                }
            }
        }

        return max;
    }

    Matrix operator+(const Matrix& other) const {
        Matrix temp(rows, cols);

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                temp.data[i][j] = data[i][j] + other.data[i][j];
            }
        }

        return temp;
    }

    Matrix operator-(const Matrix& other) const {
        Matrix temp(rows, cols);

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                temp.data[i][j] = data[i][j] - other.data[i][j];
            }
        }

        return temp;
    }

    Matrix operator*(const Matrix& other) const {
        Matrix temp(rows, cols);

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                temp.data[i][j] = data[i][j] * other.data[i][j];
            }
        }

        return temp;
    }

    Matrix operator/(const Matrix& other) const {
        Matrix temp(rows, cols);

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                temp.data[i][j] = data[i][j] / other.data[i][j];
            }
        }

        return temp;
    }
};

int main() {
    srand(time(0));

    int rows, cols;

    cout << "Enter number of rows: ";
    cin >> rows;

    cout << "Enter number of columns: ";
    cin >> cols;

    Matrix<int> m1(rows, cols);
    Matrix<int> m2(rows, cols);

    cout << endl;
    cout << "Matrix 1 random fill:" << endl;
    m1.fillRandom();
    m1.print();

    cout << endl;
    cout << "Matrix 2 random fill:" << endl;
    m2.fillRandom();
    m2.print();

    Matrix<int> sum = m1 + m2;
    Matrix<int> sub = m1 - m2;
    Matrix<int> mul = m1 * m2;
    Matrix<int> div = m1 / m2;

    cout << endl;
    cout << "Sum matrix:" << endl;
    sum.print();

    cout << endl;
    cout << "Subtraction matrix:" << endl;
    sub.print();

    cout << endl;
    cout << "Multiplication matrix:" << endl;
    mul.print();

    cout << endl;
    cout << "Division matrix:" << endl;
    div.print();

    cout << endl;
    cout << "Min element in Matrix 1: " << m1.findMin() << endl;
    cout << "Max element in Matrix 1: " << m1.findMax() << endl;

    return 0;
}