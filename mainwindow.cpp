#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

// Додавання задачі
void MainWindow::on_addButton_clicked()
{
    QString task = ui->lineEdit->text();

    if (task.isEmpty()) {
        ui->label->setText("User!!! Enter text!");
        return;
    }

    ui->listWidget->addItem(task);
    ui->lineEdit->clear();
    ui->label->setText("Added!");
}

// Видалення задачі
void MainWindow::on_deleteButton_clicked()
{
    QListWidgetItem *item = ui->listWidget->currentItem();

    if (item == nullptr) {
        ui->label->setText("Оберіть задачу");
        return;
    }

    delete item;
    ui->label->setText("Видалено!");
}

// Подвійний клік — відмітка виконання
void MainWindow::on_listWidget_itemDoubleClicked(QListWidgetItem *item)
{
    QString text = item->text();

    if (text.startsWith("✓ ")) {
        item->setText(text.mid(2)); // зняти галочку
        ui->label->setText("Позначку знято!");
    } else {
        item->setText("✓ " + text); // поставити галочку
        ui->label->setText("Позначено як виконане!");
    }
}