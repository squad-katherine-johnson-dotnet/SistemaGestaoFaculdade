# 🎓 Sistema de Gestão de Faculdade

Projeto desenvolvido em squad como parte do desafio de **Programação Orientada a Objetos com C#**.

## 🎯 Objetivo

Desenvolver um sistema em C# que permita **gerenciar informações acadêmicas de alunos, professores, cursos e disciplinas, além de realizar matrículas, lançar notas, consultar boletins e enviar notificações**.

O desafio também tem como objetivo praticar a **aplicação de regras de negócio, divisão de tarefas, integração do código, testes e trabalho colaborativo em equipe**.

## 📌 Funcionalidades

O sistema permite:

- Cadastrar curso;
- Cadastrar professor;
- Cadastrar aluno;
- Cadastrar disciplina;
- Vincular disciplina a um curso;
- Matricular aluno em curso;
- Lançar nota;
- Consultar pessoas;
- Consultar cursos;
- Consultar matrículas;
- Consultar boletim;
- Enviar notificação.

## 🧠 Regras de negócio

### 🏛️ Curso & disciplina

- Cada curso possui **código, nome e tipo**: Graduação ou Pós-graduação.

- Um curso pode possuir várias disciplinas, e cada disciplina possui um professor responsável, que deve estar previamente cadastrado.

- Uma disciplina deve ser vinculada a um curso para fazer parte dele.

- A mesma disciplina não pode ser adicionada duas vezes ao mesmo curso.

- Código de curso e código de disciplina não podem se repetir.

### 👥 Pessoas

- Professor possui **nome, CPF, e-mail, registro e especialidade**. CPF e registro devem ser únicos.

- Aluno possui **nome, CPF, e-mail e número de matrícula**. CPF e matrícula devem ser únicos.

- O cadastro do aluno não exige a escolha de um curso naquele momento.

- Alunos e professores devem poder receber notificações.

### 📋 Matrícula & boletim

- Um aluno pode estar matriculado em vários cursos, mas nunca duas vezes no mesmo curso.

- O aluno e o curso precisam existir antes da realização da matrícula.

- Cada matrícula gera automaticamente um boletim próprio.

- O boletim deve armazenar somente as notas das disciplinas pertencentes àquele curso. Notas de um curso não podem aparecer no boletim de outro curso.

### 📝 Notas & aprovação

- A nota deve estar sempre entre 0 e 10.

- Para lançar uma nota, o aluno deve estar matriculado no curso, a disciplina deve pertencer ao curso e deve existir um boletim associado à matrícula.

- **Graduação**: nota ≥ 7 → Aprovado.

- **Pós-graduação**: nota ≥ 8 → Aprovado.

- A regra de aprovação é determinada pelo tipo do curso da matrícula.

