
Este é um sistema que consiste em aplicar os conhecimentos na linguagem C# utilizando o Asp.NET para compor aplicações Web e persistindo dados com SQLite

Neste sistema possuem duas categorias de funcionário: Attendant e Recepcionists.

Ambos compartilham de uma mesma classe Pai, porém possuem alguns métodos distintos:
	
 • A classe Recepcionists:
    Tem a função de cadastrar e realizar a inserção de planos para clientes;
 • A classe attendant:
    Logo após o cliente ser cadastrado, o Attendant vai direcionar o cliente para o console em específico e definir qual será seu jogo;
 • Clientes:
	Caso o cliente opte por Planos (A, B, C) ele será um cliente premium e terá direito à um banco de horas que ficará no sistema 
	poderá utilizar as horas à qualquer momento (desde que a locadora esteja aberta)
	Caso o cliente opte por não utilizar os planos será um cliente common e seu tempo para jogar não será armazenado no sistema
	irá somente jogar a quantidade de tempo definida, tendo a possibilidade de abandono durante seu tempo de jogo.
        
