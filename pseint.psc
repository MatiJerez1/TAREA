Algoritmo sin_titulo
	definir ncant, contador,dato como entero
	Escribir "Cuantos datos desea Ingresar: "
	Leer ncant
	dimension datos[ ncant]
	Para i<-1 Hasta ncant Hacer
		Escribir "Ingrese el numero "
		Leer dato
		datos[i] <- dato
	FinPara
	Escribir "Que numero desea Ingresar?: "
	Leer busqueda
	Para j<-1 Hasta ncant Hacer
		Si datos[j] == busqueda Entonces
			contador = contador+1
		FinSi
	FinPara
	Escribir "El numero de veces que se repite el numero buscado es: ",contador
FinAlgoritmo
