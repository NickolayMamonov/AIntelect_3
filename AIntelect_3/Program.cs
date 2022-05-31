using System;
using chen0040.ExpertSystem;

var inferenceEngine = new RuleInferenceEngine();

var rule = new Rule("Иномарка или нет");
rule.AddAntecedent(new IsClause("Значение иномарки", "1"));
rule.setConsequent(new IsClause("Иномарка", "да"));
inferenceEngine.AddRule(rule);

rule = new Rule("Иномарка или нет");
rule.AddAntecedent(new IsClause("Значение иномарки", "0"));
rule.setConsequent(new IsClause("Иномарка", "нет"));
inferenceEngine.AddRule(rule);

rule = new Rule("Возраст автомобиля");
rule.AddAntecedent(new GreaterClause("Значение возраста", "19"));
rule.setConsequent(new IsClause("Подходящий возраст", "да"));
inferenceEngine.AddRule(rule);

rule = new Rule("Возраст автомобиля");
rule.AddAntecedent(new LessClause("Значение возраста", "20"));
rule.setConsequent(new IsClause("Подходящий возраст", "нет"));
inferenceEngine.AddRule(rule);

rule = new Rule("Пробег автомобиля");
rule.AddAntecedent(new GreaterClause("Значение пробега", "50000"));
rule.setConsequent(new IsClause("Подходящий пробег", "нет"));
inferenceEngine.AddRule(rule);

rule = new Rule("Возраст автомобиля");
rule.AddAntecedent(new LessClause("Значение пробега", "50001"));
rule.setConsequent(new IsClause("Подходящий пробег", "да"));
inferenceEngine.AddRule(rule);

rule = new Rule("Цвет автомобиля");
rule.AddAntecedent(new IsClause("Значение цвета", "1"));
rule.setConsequent(new IsClause("Темный цвет", "нет"));
inferenceEngine.AddRule(rule);

rule = new Rule("Цвет автомобиля");
rule.AddAntecedent(new IsClause("Значение цвета", "0"));
rule.setConsequent(new IsClause("Темный цвет", "да"));
inferenceEngine.AddRule(rule);

// Иномарка - нет
rule = new Rule("Покупаем или нет");
rule.AddAntecedent(new IsClause("Иномарка", "да"));
rule.AddAntecedent(new IsClause("Подходящий возраст", "да"));
rule.AddAntecedent(new IsClause("Подходящий пробег", "да"));
rule.setConsequent(new IsClause("Покупаем", "да"));
inferenceEngine.AddRule(rule);

rule = new Rule("Покупаем или нет");
rule.AddAntecedent(new IsClause("Иномарка", "нет"));
rule.AddAntecedent(new IsClause("Подходящий возраст", "нет"));
rule.AddAntecedent(new IsClause("Подходящий пробег", "нет"));
rule.setConsequent(new IsClause("Покупаем", "нет"));
inferenceEngine.AddRule(rule);

rule = new Rule("Покупаем или нет");
rule.AddAntecedent(new IsClause("Иномарка", "нет"));
rule.AddAntecedent(new IsClause("Подходящий возраст", "нет"));
rule.AddAntecedent(new IsClause("Подходящий пробег", "да"));
rule.setConsequent(new IsClause("Покупаем", "нет"));
inferenceEngine.AddRule(rule);

rule = new Rule("Покупаем или нет");
rule.AddAntecedent(new IsClause("Иномарка", "нет"));
rule.AddAntecedent(new IsClause("Подходящий возраст", "да"));
rule.AddAntecedent(new IsClause("Подходящий пробег", "да"));
rule.setConsequent(new IsClause("Покупаем", "да"));
inferenceEngine.AddRule(rule);

rule = new Rule("Покупаем или нет");
rule.AddAntecedent(new IsClause("Иномарка", "нет"));
rule.AddAntecedent(new IsClause("Подходящий возраст", "да"));
rule.AddAntecedent(new IsClause("Подходящий пробег", "нет"));
rule.setConsequent(new IsClause("Покупаем", "нет"));
inferenceEngine.AddRule(rule);

//Иномарка - да
rule = new Rule("Покупаем или нет");
rule.AddAntecedent(new IsClause("Иномарка", "да"));
rule.AddAntecedent(new IsClause("Подходящий возраст", "нет"));
rule.AddAntecedent(new IsClause("Подходящий пробег", "нет"));
rule.setConsequent(new IsClause("Покупаем", "нет"));
inferenceEngine.AddRule(rule);

rule = new Rule("Покупаем или нет");
rule.AddAntecedent(new IsClause("Иномарка", "да"));
rule.AddAntecedent(new IsClause("Подходящий возраст", "нет"));
rule.AddAntecedent(new IsClause("Подходящий пробег", "да"));
rule.setConsequent(new IsClause("Покупаем", "нет"));
inferenceEngine.AddRule(rule);

rule = new Rule("Покупаем или нет");
rule.AddAntecedent(new IsClause("Иномарка", "да"));
rule.AddAntecedent(new IsClause("Подходящий возраст", "да"));
rule.AddAntecedent(new IsClause("Подходящий пробег", "да"));
rule.setConsequent(new IsClause("Покупаем", "да"));
inferenceEngine.AddRule(rule);

rule = new Rule("Покупаем или нет");
rule.AddAntecedent(new IsClause("Иномарка", "да"));
rule.AddAntecedent(new IsClause("Подходящий возраст", "да"));
rule.AddAntecedent(new IsClause("Подходящий пробег", "нет"));
rule.setConsequent(new IsClause("Покупаем", "нет"));
inferenceEngine.AddRule(rule);

Console.WriteLine("Введите значения через пробел:");

string str = Console.ReadLine()!;

inferenceEngine.AddFact(new IsClause("Значение иномарки", str.Split(" ")[0]));
inferenceEngine.AddFact(new IsClause("Значение возраста", str.Split(" ")[1]));
inferenceEngine.AddFact(new IsClause("Значение пробега", str.Split(" ")[2]));
inferenceEngine.AddFact(new IsClause("Значение цвета", str.Split(" ")[3]));

inferenceEngine.Infer();
Console.WriteLine("Факты:");
Console.WriteLine(inferenceEngine.Facts); 

inferenceEngine.Infer();
var conclusion = inferenceEngine.Facts.IsFact(new IsClause("Покупаем", "да")); 
Console.WriteLine("Вывод:");
Console.WriteLine(conclusion ? "Покупаем" : "Определить невозможно");