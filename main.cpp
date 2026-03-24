#include <iostream>
using namespace std;

class Date {
private:
    int day;
    int month;
    int year;

public:
    Date() {
        day = 1;
        month = 1;
        year = 2000;
    }

    Date(int d, int m, int y) {
        day = d;
        month = m;
        year = y;
    }

    // copy
    Date(const Date& other) {
        day = other.day;
        month = other.month;
        year = other.year;
    }

    // =
    Date& operator=(const Date& other) {
        if (this != &other) {
            day = other.day;
            month = other.month;
            year = other.year;
        }
        return *this;
    }

    // increase day by 1
    void nextDay() {
        day++;
        if (day > 30) {
            day = 1;
            month++;
            if (month > 12) {
                month = 1;
                year++;
            }
        }
    }

    // ++ prefix
    Date operator++() {
        nextDay();
        return *this;
    }

    // ++ postfix
    Date operator++(int) {
        Date temp = *this;
        nextDay();
        return temp;
    }

    // -- prefix
    Date operator--() {
        day--;
        if (day < 1) {
            day = 30;
            month--;
            if (month < 1) {
                month = 12;
                year--;
            }
        }
        return *this;
    }

    // -- postfix
    Date operator--(int) {
        Date temp = *this;
        --(*this);
        return temp;
    }

    // +=
    Date operator+=(int days) {
        for (int i = 0; i < days; i++) {
            nextDay();
        }
        return *this;
    }

    // -=
    Date operator-=(int days) {
        for (int i = 0; i < days; i++) {
            --(*this);
        }
        return *this;
    }

    friend bool operator==(const Date& a, const Date& b);
    friend bool operator!=(const Date& a, const Date& b);
    friend bool operator>(const Date& a, const Date& b);
    friend bool operator<(const Date& a, const Date& b);

    friend ostream& operator<<(ostream& out, const Date& d);
    friend istream& operator>>(istream& in, Date& d);
};

bool operator==(const Date& a, const Date& b) {
    return (a.day == b.day && a.month == b.month && a.year == b.year);
}

bool operator!=(const Date& a, const Date& b) {
    return !(a == b);
}

bool operator>(const Date& a, const Date& b) {
    if (a.year > b.year) return true;
    if (a.year == b.year && a.month > b.month) return true;
    if (a.year == b.year && a.month == b.month && a.day > b.day) return true;
    return false;
}

bool operator<(const Date& a, const Date& b) {
    if (a.year < b.year) return true;
    if (a.year == b.year && a.month < b.month) return true;
    if (a.year == b.year && a.month == b.month && a.day < b.day) return true;
    return false;
}

ostream& operator<<(ostream& out, const Date& d) {
    out << d.day << "." << d.month << "." << d.year;
    return out;
}

istream& operator>>(istream& in, Date& d) {
    cout << "Enter day month year: ";
    in >> d.day >> d.month >> d.year;
    return in;
}


// ===== MAIN =====

int main() {

    Date d1, d2;

    cin >> d1;
    cin >> d2;

    cout << "Date 1: " << d1 << endl;
    cout << "Date 2: " << d2 << endl;

    cout << endl;

    // ++
    d1++;
    cout << "After ++: " << d1 << endl;

    // --
    d1--;
    cout << "After --: " << d1 << endl;

    // +=
    d1 += 5;
    cout << "After +=5: " << d1 << endl;

    // -=
    d1 -= 3;
    cout << "After -=3: " << d1 << endl;

    cout << endl;

    // compare
    if (d1 == d2)
        cout << "Dates are equal" << endl;
    else
        cout << "Dates are not equal" << endl;

    if (d1 > d2)
        cout << "Date1 is greater" << endl;
    else if (d1 < d2)
        cout << "Date1 is smaller" << endl;

    return 0;
}