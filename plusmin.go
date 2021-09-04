package main

import (
	"fmt"
	"math"
)

// code goes here
// Задача: между цифрами числа dig расставиьт знаки +-, чтобы получить sum

func main() {
	var dig int = 1234
	sum := 10             // Искомое значение выражения
	count, target := 0, 0 // Счетчики выражений

	var digAray []int = ToArray(dig) // Исходное число в виде множества цифр
	fmt.Println("Введено число:", digAray)
	fmt.Print("Количество цифр в числе: ", len(digAray), "\t")
	maxc := Combs(len(digAray))
	fmt.Println("Расставим знаки +- между цифр.")
	fmt.Println("Получили количество выражений =", maxc)
	fmt.Println("Найдем выражения с результатом", sum, ":")

	// Составляем все возможные комбинации знаков
	for i := 0; i < maxc; i++ {
		k := i // Номер текущего выражения из общего числа комбинаций maxc

		da := digAray[0] // Исходное значение. Первая цифра числа dig

		// Первую  цифру числа dig последовательно увеличиваем(уменьшаем)
		// на значение следующих цифр с нарастающим остатком
		for j := 1; j < len(digAray); j++ {

			if k%2 == 0 {
				da += digAray[j]
			} else {
				da -= digAray[j]
			}
			k = k >> 1 // Операция смещения на 1 бит для чередования знаков в выражении
			// (равняется количеству целых (1*2) двоек в числе)
		}
		count++
		// Считаем сколько выражений достигли цели target
		if da == sum {
			target++
		}

		//Выведем выражения на экран

		fmt.Print("\n", count, ")\t")
		fmt.Print(digAray[0])
		k = i
		for j := 1; j < len(digAray); j++ {
			s := "" // Знаковая переменная (+-)

			if k%2 == 0 {
				s = "+"
			} else {
				s = "-"
			}

			fmt.Print(s, digAray[j])
			k = k >> 1
		}
		fmt.Print(" = ", da)
	}

	fmt.Println()

	if target == 0 {
		fmt.Println("Искомая комбинация не найдена.")
	} else {
		fmt.Println("Найдено", target)
	}

	fmt.Println("The End")
}

// Переводит число в массив
func ToArray(a int) []int {
	i, j, x := 0, 0, 0
	var numbers, s []int
	for {
		x = a % 10
		numbers = append(numbers, x)
		i++
		a = a / 10
		if a < 1 {
			break
		}
	}
	// перевернуть Slise
	for i = len(numbers) - 1; i >= 0; i-- {
		s = append(s, numbers[i])
		j++
	}
	return s
}

// Считает  число сочетаний из x элементов
func Combs(x int) int {
	m := float64(x)
	max := math.Pow(2, m-1)
	return int(max)
}
