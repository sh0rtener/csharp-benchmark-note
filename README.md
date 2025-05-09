# Заметка о способе оценки производительности на C# с помощью BenchmarkDotNet
(nuget - https://www.nuget.org/packages/BenchmarkDotNet/)<br/>

### Необходимые понятия для понимания:
- Mean - среднее время выполнения
- StdDev - число отклонения оценки
- Error - ошибки оценки от 99.9
- Ratio - оценка улучшения или ухудшения по отношению к BaseLine = true в процентах
- Allocated - сколько выделено памяти


### Пример

```
int[] array = GenerateSortedArray(1000);
int value = 78;

| Method          | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| FindIndexBinary |  3.393 ns | 0.0196 ns | 0.0163 ns |  0.08 |    0.00 |         - |          NA |
| FindIndexLinear | 43.665 ns | 0.7275 ns | 0.6449 ns |  1.00 |    0.02 |         - |          NA |
```

Эту таблицу можно расшифровать так:
- Метод FindIndexBinary выполняется на ~40ns быстрее, чем метод FindIndexLinear
- Число отклонения оценки у метода FindIndexBinary равено 0.0163 ns (погрешность)
- Т.к метод FindIndexLinear является Baseline = true, то относительно этого метода метод FindIndexBinary лучше на 8%
