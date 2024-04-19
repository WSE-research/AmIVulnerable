# Statistiken
- [Zeitunterschied Abfrage auf den Datenbanken Mono-Pipe  Fall: weniger Pakete als Datenbanken](#zeitunterschied-abfrage-auf-den-datenbanken-mono-pipe--fall-weniger-pakete-als-datenbanken)
  - [Durchgang 1 von 10](#durchgang-1-von-10)
  - [Durchgang 2 von 10](#durchgang-2-von-10)
  - [Durchgang 3 von 10](#durchgang-3-von-10)
  - [Durchgang 4 von 10](#durchgang-4-von-10)
  - [Durchgang 5 von 10](#durchgang-5-von-10)
  - [Durchgang 6 von 10](#durchgang-6-von-10)
  - [Durchgang 7 von 10](#durchgang-7-von-10)
  - [Durchgang 8 von 10](#durchgang-8-von-10)
  - [Durchgang 9 von 10](#durchgang-9-von-10)
  - [Durchgang 10 von 10](#durchgang-10-von-10)
  - [Erkenntnisse](#erkenntnisse)
- [Zeitunterschied Abfrage auf den Datenbanken Mono-Pipe  Fall: mehr Pakete als Datenbanken](#zeitunterschied-abfrage-auf-den-datenbanken-mono-pipe--fall-mehr-pakete-als-datenbanken)
  - [Durchgang 1 von 10](#durchgang-1-von-10-1)
  - [Durchgang 2 von 10](#durchgang-2-von-10-1)
  - [Durchgang 3 von 10](#durchgang-3-von-10-1)
  - [Durchgang 4 von 10](#durchgang-4-von-10-1)
  - [Durchgang 5 von 10](#durchgang-5-von-10-1)
  - [Durchgang 6 von 10](#durchgang-6-von-10-1)
  - [Durchgang 7 von 10](#durchgang-7-von-10-1)
  - [Durchgang 8 von 10](#durchgang-8-von-10-1)
  - [Durchgang 9 von 10](#durchgang-9-von-10-1)
  - [Durchgang 10 von 10](#durchgang-10-von-10-1)
  - [Erkenntnisse](#erkenntnisse-1)

## Zeitunterschied Abfrage auf den Datenbanken Mono-Pipe <br> Fall: weniger Pakete als Datenbanken
### Durchgang 1 von 10
```log
2024-02-20 16:52:48.970 +01:00 [INF] Time by mono LiteDB completed in 4147.1 ms
2024-02-20 16:52:51.848 +01:00 [INF] Time by mono Newtonsoft completed in 2866.1 ms
2024-02-20 16:52:54.625 +01:00 [INF] Time by mono NewtonSoft completed in 2776.4 ms
2024-02-20 16:52:57.421 +01:00 [INF] Time by mono Crowd completed in 2796.2 ms
2024-02-20 16:53:00.201 +01:00 [INF] Time by mono Atlassian completed in 2779.7 ms
2024-02-20 16:53:02.980 +01:00 [INF] Time by mono Debian completed in 2779.5 ms
2024-02-20 16:53:05.740 +01:00 [INF] Time by mono Ubuntu completed in 2760.0 ms
2024-02-20 16:53:08.605 +01:00 [INF] Time by mono Arc42 completed in 2864.0 ms
2024-02-20 16:53:13.009 +01:00 [INF] Time by mono arc42 completed in 4404.5 ms
2024-02-20 16:53:24.805 +01:00 [INF] Time by pipe completed in 11794.7 ms
```
Durchschnitt Mono: 3130,3889ms <br>
Laufzeit der Pipe: 11794,7ms <br>
Gesamt Mono: 28173,5ms<br>
Faktor: 2,388657617

### Durchgang 2 von 10
```log
2024-02-20 16:54:34.973 +01:00 [INF] Time by mono LiteDB completed in 4004.3 ms
2024-02-20 16:54:37.857 +01:00 [INF] Time by mono Newtonsoft completed in 2866.0 ms
2024-02-20 16:54:40.656 +01:00 [INF] Time by mono NewtonSoft completed in 2799.1 ms
2024-02-20 16:54:43.436 +01:00 [INF] Time by mono Crowd completed in 2780.3 ms
2024-02-20 16:54:46.207 +01:00 [INF] Time by mono Atlassian completed in 2770.9 ms
2024-02-20 16:54:48.966 +01:00 [INF] Time by mono Debian completed in 2758.1 ms
2024-02-20 16:54:51.740 +01:00 [INF] Time by mono Ubuntu completed in 2774.3 ms
2024-02-20 16:54:54.543 +01:00 [INF] Time by mono Arc42 completed in 2803.2 ms
2024-02-20 16:54:57.289 +01:00 [INF] Time by mono arc42 completed in 2745.9 ms
2024-02-20 16:55:07.436 +01:00 [INF] Time by pipe completed in 10146.6 ms
```
Durchschnitt Mono: 2922,4555ms <br>
Laufzeit der Pipe: 10146,6ms <br>
Gesamt Mono: 26302,1ms<br>
Faktor: 2,592208227

### Durchgang 3 von 10
```log
2024-02-20 16:55:57.166 +01:00 [INF] Time by mono LiteDB completed in 4102.0 ms
2024-02-20 16:55:59.938 +01:00 [INF] Time by mono Newtonsoft completed in 2761.0 ms
2024-02-20 16:56:02.704 +01:00 [INF] Time by mono NewtonSoft completed in 2766.5 ms
2024-02-20 16:56:05.472 +01:00 [INF] Time by mono Crowd completed in 2767.9 ms
2024-02-20 16:56:08.227 +01:00 [INF] Time by mono Atlassian completed in 2754.5 ms
2024-02-20 16:56:10.970 +01:00 [INF] Time by mono Debian completed in 2742.7 ms
2024-02-20 16:56:13.729 +01:00 [INF] Time by mono Ubuntu completed in 2759.3 ms
2024-02-20 16:56:16.484 +01:00 [INF] Time by mono Arc42 completed in 2754.3 ms
2024-02-20 16:56:19.254 +01:00 [INF] Time by mono arc42 completed in 2770.2 ms
2024-02-20 16:56:28.535 +01:00 [INF] Time by pipe completed in 9281.4 ms
```
Durchschnitt Mono: 2908,7111ms <br>
Laufzeit der Pipe: 9281,4ms <br>
Gesamt Mono: 26178,4ms<br>
Faktor: 2,820522766

### Durchgang 4 von 10
```log
2024-02-20 16:57:34.891 +01:00 [INF] Time by mono LiteDB completed in 4750.3 ms
2024-02-20 16:57:37.679 +01:00 [INF] Time by mono Newtonsoft completed in 2777.6 ms
2024-02-20 16:57:40.432 +01:00 [INF] Time by mono NewtonSoft completed in 2752.7 ms
2024-02-20 16:57:43.144 +01:00 [INF] Time by mono Crowd completed in 2712.3 ms
2024-02-20 16:57:45.869 +01:00 [INF] Time by mono Atlassian completed in 2724.7 ms
2024-02-20 16:57:48.584 +01:00 [INF] Time by mono Debian completed in 2715.0 ms
2024-02-20 16:57:51.292 +01:00 [INF] Time by mono Ubuntu completed in 2708.1 ms
2024-02-20 16:57:53.999 +01:00 [INF] Time by mono Arc42 completed in 2706.5 ms
2024-02-20 16:57:56.718 +01:00 [INF] Time by mono arc42 completed in 2718.8 ms
2024-02-20 16:58:06.284 +01:00 [INF] Time by pipe completed in 9566.3 ms
```
Durchschnitt Mono: 2951,7777ms <br>
Laufzeit der Pipe: 9566,3ms <br>
Gesamt Mono: 26566ms<br>
Faktor: 2,777040235

### Durchgang 5 von 10
```log
2024-02-20 16:58:52.421 +01:00 [INF] Time by mono LiteDB completed in 4087.7 ms
2024-02-20 16:58:55.148 +01:00 [INF] Time by mono Newtonsoft completed in 2716.4 ms
2024-02-20 16:58:57.845 +01:00 [INF] Time by mono NewtonSoft completed in 2697.0 ms
2024-02-20 16:59:00.541 +01:00 [INF] Time by mono Crowd completed in 2696.4 ms
2024-02-20 16:59:03.256 +01:00 [INF] Time by mono Atlassian completed in 2714.8 ms
2024-02-20 16:59:05.957 +01:00 [INF] Time by mono Debian completed in 2700.4 ms
2024-02-20 16:59:08.659 +01:00 [INF] Time by mono Ubuntu completed in 2701.9 ms
2024-02-20 16:59:11.364 +01:00 [INF] Time by mono Arc42 completed in 2705.2 ms
2024-02-20 16:59:14.060 +01:00 [INF] Time by mono arc42 completed in 2696.0 ms
2024-02-20 16:59:23.294 +01:00 [INF] Time by pipe completed in 9233.7 ms
```
Durchschnitt Mono: 2857,3111ms <br>
Laufzeit der Pipe: 9233,7ms <br>
Gesamt Mono: 25715,8ms<br>
Faktor: 2,784994098

### Durchgang 6 von 10
```log
2024-02-20 17:00:07.005 +01:00 [INF] Time by mono LiteDB completed in 4338.2 ms
2024-02-20 17:00:09.769 +01:00 [INF] Time by mono Newtonsoft completed in 2753.6 ms
2024-02-20 17:00:12.514 +01:00 [INF] Time by mono NewtonSoft completed in 2744.4 ms
2024-02-20 17:00:15.243 +01:00 [INF] Time by mono Crowd completed in 2729.1 ms
2024-02-20 17:00:17.996 +01:00 [INF] Time by mono Atlassian completed in 2753.0 ms
2024-02-20 17:00:20.738 +01:00 [INF] Time by mono Debian completed in 2741.7 ms
2024-02-20 17:00:23.465 +01:00 [INF] Time by mono Ubuntu completed in 2726.5 ms
2024-02-20 17:00:26.193 +01:00 [INF] Time by mono Arc42 completed in 2728.0 ms
2024-02-20 17:00:28.908 +01:00 [INF] Time by mono arc42 completed in 2715.0 ms
2024-02-20 17:00:38.115 +01:00 [INF] Time by pipe completed in 9207.4 ms
```
Durchschnitt Mono: 2914,3888ms <br>
Laufzeit der Pipe: 9207,4ms <br>
Gesamt Mono: 26229,5ms<br>
Faktor: 2,84874123

### Durchgang 7 von 10
```log
2024-02-20 17:01:15.254 +01:00 [INF] Time by mono LiteDB completed in 4183.9 ms
2024-02-20 17:01:18.155 +01:00 [INF] Time by mono Newtonsoft completed in 2882.7 ms
2024-02-20 17:01:20.884 +01:00 [INF] Time by mono NewtonSoft completed in 2729.3 ms
2024-02-20 17:01:23.624 +01:00 [INF] Time by mono Crowd completed in 2740.1 ms
2024-02-20 17:01:26.347 +01:00 [INF] Time by mono Atlassian completed in 2722.7 ms
2024-02-20 17:01:29.068 +01:00 [INF] Time by mono Debian completed in 2721.1 ms
2024-02-20 17:01:31.809 +01:00 [INF] Time by mono Ubuntu completed in 2740.8 ms
2024-02-20 17:01:34.544 +01:00 [INF] Time by mono Arc42 completed in 2734.4 ms
2024-02-20 17:01:37.332 +01:00 [INF] Time by mono arc42 completed in 2788.2 ms
2024-02-20 17:01:46.705 +01:00 [INF] Time by pipe completed in 9372.5 ms
```
Durchschnitt Mono: 2915,9111ms <br>
Laufzeit der Pipe: 9372,5ms <br>
Gesamt Mono: 26243,2ms<br>
Faktor: 2,800021339

### Durchgang 8 von 10
```log
2024-02-20 17:02:26.668 +01:00 [INF] Time by mono LiteDB completed in 4080.0 ms
2024-02-20 17:02:29.378 +01:00 [INF] Time by mono Newtonsoft completed in 2699.1 ms
2024-02-20 17:02:32.081 +01:00 [INF] Time by mono NewtonSoft completed in 2703.3 ms
2024-02-20 17:02:34.793 +01:00 [INF] Time by mono Crowd completed in 2711.8 ms
2024-02-20 17:02:37.499 +01:00 [INF] Time by mono Atlassian completed in 2706.1 ms
2024-02-20 17:02:40.194 +01:00 [INF] Time by mono Debian completed in 2694.4 ms
2024-02-20 17:02:42.884 +01:00 [INF] Time by mono Ubuntu completed in 2689.8 ms
2024-02-20 17:02:45.583 +01:00 [INF] Time by mono Arc42 completed in 2699.5 ms
2024-02-20 17:02:48.283 +01:00 [INF] Time by mono arc42 completed in 2699.5 ms
2024-02-20 17:02:57.652 +01:00 [INF] Time by pipe completed in 9369.2 ms
```
Durchschnitt Mono: 2853,7222ms <br>
Laufzeit der Pipe: 9369,2ms <br>
Gesamt Mono: 25683,5ms<br>
Faktor: 2,741269265

### Durchgang 9 von 10
```log
2024-02-20 17:03:46.609 +01:00 [INF] Time by mono LiteDB completed in 4061.9 ms
2024-02-20 17:03:49.326 +01:00 [INF] Time by mono Newtonsoft completed in 2706.6 ms
2024-02-20 17:03:52.066 +01:00 [INF] Time by mono NewtonSoft completed in 2739.0 ms
2024-02-20 17:03:54.813 +01:00 [INF] Time by mono Crowd completed in 2746.9 ms
2024-02-20 17:03:57.524 +01:00 [INF] Time by mono Atlassian completed in 2711.0 ms
2024-02-20 17:04:00.245 +01:00 [INF] Time by mono Debian completed in 2721.0 ms
2024-02-20 17:04:02.960 +01:00 [INF] Time by mono Ubuntu completed in 2714.8 ms
2024-02-20 17:04:05.664 +01:00 [INF] Time by mono Arc42 completed in 2703.6 ms
2024-02-20 17:04:08.370 +01:00 [INF] Time by mono arc42 completed in 2706.4 ms
2024-02-20 17:04:17.750 +01:00 [INF] Time by pipe completed in 9380.2 ms
```
Durchschnitt Mono: 2867,9111ms <br>
Laufzeit der Pipe: 9380,2ms <br>
Gesamt Mono: 25811,2ms<br>
Faktor: 2,751668408

### Durchgang 10 von 10
```log
2024-02-20 17:04:49.929 +01:00 [INF] Time by mono LiteDB completed in 4049.1 ms
2024-02-20 17:04:52.685 +01:00 [INF] Time by mono Newtonsoft completed in 2746.2 ms
2024-02-20 17:04:55.396 +01:00 [INF] Time by mono NewtonSoft completed in 2711.0 ms
2024-02-20 17:04:58.101 +01:00 [INF] Time by mono Crowd completed in 2704.9 ms
2024-02-20 17:05:00.809 +01:00 [INF] Time by mono Atlassian completed in 2707.1 ms
2024-02-20 17:05:03.515 +01:00 [INF] Time by mono Debian completed in 2706.5 ms
2024-02-20 17:05:06.216 +01:00 [INF] Time by mono Ubuntu completed in 2700.4 ms
2024-02-20 17:05:08.940 +01:00 [INF] Time by mono Arc42 completed in 2724.0 ms
2024-02-20 17:05:11.664 +01:00 [INF] Time by mono arc42 completed in 2724.3 ms
2024-02-20 17:05:21.181 +01:00 [INF] Time by pipe completed in 9516.4 ms
```
Durchschnitt Mono: 2863,7222ms <br>
Laufzeit der Pipe: 9516,4ms <br>
Gesamt Mono: 25773,5ms<br>
Faktor: 2,708324577

### Erkenntnisse
Die durchschnittliche Laufzeit der Mono bzw. Single-Paket Analyse dauerte: 2918,63ms <br>
Die Gesamtlaufzeit von Mono beträgt: 262676,7ms <br>
Die Gesamtlaufzeit von Pipe beträgt: 96868,4ms <br>

Der Durchschnittliche Faktor (schnellere Pipe als Mono) beträgt: 2,7213448


## Zeitunterschied Abfrage auf den Datenbanken Mono-Pipe <br> Fall: mehr Pakete als Datenbanken
Noch zu messen!
### Durchgang 1 von 10
```log
2024-02-21 15:05:20.021 +01:00 [INF] Time by mono LiteDB completed in 7208.9 ms
2024-02-21 15:05:22.798 +01:00 [INF] Time by mono Newtonsoft completed in 2765.7 ms
2024-02-21 15:05:25.526 +01:00 [INF] Time by mono NewtonSoft completed in 2728.0 ms
2024-02-21 15:05:28.264 +01:00 [INF] Time by mono Crowd completed in 2737.9 ms
2024-02-21 15:05:30.992 +01:00 [INF] Time by mono Atlassian completed in 2727.2 ms
2024-02-21 15:05:33.706 +01:00 [INF] Time by mono Debian completed in 2714.1 ms
2024-02-21 15:05:36.408 +01:00 [INF] Time by mono Ubuntu completed in 2702.3 ms
2024-02-21 15:05:39.095 +01:00 [INF] Time by mono Arc42 completed in 2687.2 ms
2024-02-21 15:05:41.794 +01:00 [INF] Time by mono arc42 completed in 2698.7 ms
2024-02-21 15:05:44.499 +01:00 [INF] Time by mono cookie completed in 2694.2 ms
2024-02-21 15:05:47.205 +01:00 [INF] Time by mono mongoDb completed in 2705.9 ms
2024-02-21 15:05:49.908 +01:00 [INF] Time by mono mongoDB completed in 2702.4 ms
2024-02-21 15:05:52.610 +01:00 [INF] Time by mono mongodb completed in 2702.4 ms
2024-02-21 15:05:55.377 +01:00 [INF] Time by mono parser completed in 2766.6 ms
2024-02-21 15:05:58.095 +01:00 [INF] Time by mono LiteDb completed in 2718.1 ms
2024-02-21 15:06:00.962 +01:00 [INF] Time by mono php completed in 2866.8 ms
2024-02-21 15:06:03.677 +01:00 [INF] Time by mono PHP completed in 2715.3 ms
2024-02-21 15:06:06.399 +01:00 [INF] Time by mono Laravel completed in 2721.7 ms
2024-02-21 15:06:09.108 +01:00 [INF] Time by mono laravel completed in 2709.1 ms
2024-02-21 15:06:11.835 +01:00 [INF] Time by mono LARAVEL completed in 2726.8 ms
2024-02-21 15:06:14.549 +01:00 [INF] Time by mono beta completed in 2713.3 ms
2024-02-21 15:06:17.265 +01:00 [INF] Time by mono meta completed in 2716.0 ms
2024-02-21 15:06:19.983 +01:00 [INF] Time by mono META completed in 2717.8 ms
2024-02-21 15:06:22.688 +01:00 [INF] Time by mono express-ejs-layouts completed in 2705.4 ms
2024-02-21 15:06:25.409 +01:00 [INF] Time by mono accepts completed in 2720.1 ms
2024-02-21 15:06:28.125 +01:00 [INF] Time by mono mime-db completed in 2716.2 ms
2024-02-21 15:06:30.829 +01:00 [INF] Time by mono mime-DB completed in 2703.7 ms
2024-02-21 15:06:33.538 +01:00 [INF] Time by mono iconv-lite completed in 2708.8 ms
2024-02-21 15:06:36.228 +01:00 [INF] Time by mono safer-buffer completed in 2690.8 ms
2024-02-21 15:06:38.929 +01:00 [INF] Time by mono raw-body completed in 2700.3 ms
2024-02-21 15:06:41.633 +01:00 [INF] Time by mono depd completed in 2704.4 ms
2024-02-21 15:06:44.338 +01:00 [INF] Time by mono finalhandler completed in 2704.6 ms
2024-02-21 15:06:47.039 +01:00 [INF] Time by mono on-finished completed in 2700.3 ms
2024-02-21 15:06:49.734 +01:00 [INF] Time by mono ipaddr.js completed in 2695.2 ms
2024-02-21 15:06:52.440 +01:00 [INF] Time by mono encodeurl completed in 2705.9 ms
2024-02-21 15:07:14.672 +01:00 [INF] Time by pipe completed in 22231.9 ms
```
Durchschnitt Mono: 2845,774286ms <br>
Laufzeit der Pipe: 22231,9ms <br>
Gesamt Mono: 99602,1ms <br>
Faktor: 4,480143397

### Durchgang 2 von 10
```log
2024-02-21 15:07:49.056 +01:00 [INF] Time by mono LiteDB completed in 3859.8 ms
2024-02-21 15:07:51.704 +01:00 [INF] Time by mono Newtonsoft completed in 2638.7 ms
2024-02-21 15:07:54.355 +01:00 [INF] Time by mono NewtonSoft completed in 2650.9 ms
2024-02-21 15:07:57.009 +01:00 [INF] Time by mono Crowd completed in 2653.7 ms
2024-02-21 15:07:59.664 +01:00 [INF] Time by mono Atlassian completed in 2654.5 ms
2024-02-21 15:08:02.306 +01:00 [INF] Time by mono Debian completed in 2642.1 ms
2024-02-21 15:08:04.973 +01:00 [INF] Time by mono Ubuntu completed in 2666.9 ms
2024-02-21 15:08:07.653 +01:00 [INF] Time by mono Arc42 completed in 2680.2 ms
2024-02-21 15:08:10.298 +01:00 [INF] Time by mono arc42 completed in 2644.9 ms
2024-02-21 15:08:12.911 +01:00 [INF] Time by mono cookie completed in 2613.2 ms
2024-02-21 15:08:15.517 +01:00 [INF] Time by mono mongoDb completed in 2605.5 ms
2024-02-21 15:08:18.112 +01:00 [INF] Time by mono mongoDB completed in 2594.6 ms
2024-02-21 15:08:20.745 +01:00 [INF] Time by mono mongodb completed in 2633.3 ms
2024-02-21 15:08:23.349 +01:00 [INF] Time by mono parser completed in 2603.7 ms
2024-02-21 15:08:25.955 +01:00 [INF] Time by mono LiteDb completed in 2605.7 ms
2024-02-21 15:08:28.573 +01:00 [INF] Time by mono php completed in 2618.1 ms
2024-02-21 15:08:31.210 +01:00 [INF] Time by mono PHP completed in 2637.3 ms
2024-02-21 15:08:33.846 +01:00 [INF] Time by mono Laravel completed in 2635.7 ms
2024-02-21 15:08:36.502 +01:00 [INF] Time by mono laravel completed in 2656.1 ms
2024-02-21 15:08:39.123 +01:00 [INF] Time by mono LARAVEL completed in 2620.6 ms
2024-02-21 15:08:41.766 +01:00 [INF] Time by mono beta completed in 2642.6 ms
2024-02-21 15:08:44.390 +01:00 [INF] Time by mono meta completed in 2624.1 ms
2024-02-21 15:08:47.030 +01:00 [INF] Time by mono META completed in 2640.4 ms
2024-02-21 15:08:49.672 +01:00 [INF] Time by mono express-ejs-layouts completed in 2641.2 ms
2024-02-21 15:08:52.319 +01:00 [INF] Time by mono accepts completed in 2647.7 ms
2024-02-21 15:08:54.957 +01:00 [INF] Time by mono mime-db completed in 2637.5 ms
2024-02-21 15:08:57.596 +01:00 [INF] Time by mono mime-DB completed in 2639.2 ms
2024-02-21 15:09:00.239 +01:00 [INF] Time by mono iconv-lite completed in 2642.4 ms
2024-02-21 15:09:02.879 +01:00 [INF] Time by mono safer-buffer completed in 2639.8 ms
2024-02-21 15:09:05.525 +01:00 [INF] Time by mono raw-body completed in 2645.7 ms
2024-02-21 15:09:08.186 +01:00 [INF] Time by mono depd completed in 2661.3 ms
2024-02-21 15:09:10.819 +01:00 [INF] Time by mono finalhandler completed in 2633.1 ms
2024-02-21 15:09:13.452 +01:00 [INF] Time by mono on-finished completed in 2632.7 ms
2024-02-21 15:09:16.074 +01:00 [INF] Time by mono ipaddr.js completed in 2622.2 ms
2024-02-21 15:09:18.712 +01:00 [INF] Time by mono encodeurl completed in 2637.7 ms
2024-02-21 15:09:40.604 +01:00 [INF] Time by pipe completed in 21891.4 ms
```
Durchschnitt Mono: 2671,517143ms <br>
Laufzeit der Pipe: 21891,4ms <br>
Gesamt Mono: 93503,1ms <br>
Faktor: 4,271225229

### Durchgang 3 von 10
```log
2024-02-21 15:19:41.636 +01:00 [INF] Time by mono LiteDB completed in 3882.4 ms
2024-02-21 15:19:44.313 +01:00 [INF] Time by mono Newtonsoft completed in 2667.4 ms
2024-02-21 15:19:46.959 +01:00 [INF] Time by mono NewtonSoft completed in 2645.8 ms
2024-02-21 15:19:49.617 +01:00 [INF] Time by mono Crowd completed in 2657.7 ms
2024-02-21 15:19:52.270 +01:00 [INF] Time by mono Atlassian completed in 2652.4 ms
2024-02-21 15:19:54.943 +01:00 [INF] Time by mono Debian completed in 2673.4 ms
2024-02-21 15:19:57.588 +01:00 [INF] Time by mono Ubuntu completed in 2644.7 ms
2024-02-21 15:20:00.243 +01:00 [INF] Time by mono Arc42 completed in 2654.8 ms
2024-02-21 15:20:02.906 +01:00 [INF] Time by mono arc42 completed in 2662.5 ms
2024-02-21 15:20:05.565 +01:00 [INF] Time by mono cookie completed in 2658.9 ms
2024-02-21 15:20:08.206 +01:00 [INF] Time by mono mongoDb completed in 2641.1 ms
2024-02-21 15:20:10.863 +01:00 [INF] Time by mono mongoDB completed in 2657.2 ms
2024-02-21 15:20:13.517 +01:00 [INF] Time by mono mongodb completed in 2653.4 ms
2024-02-21 15:20:16.181 +01:00 [INF] Time by mono parser completed in 2663.9 ms
2024-02-21 15:20:18.826 +01:00 [INF] Time by mono LiteDb completed in 2645.1 ms
2024-02-21 15:20:21.466 +01:00 [INF] Time by mono php completed in 2639.8 ms
2024-02-21 15:20:24.116 +01:00 [INF] Time by mono PHP completed in 2650.5 ms
2024-02-21 15:20:26.758 +01:00 [INF] Time by mono Laravel completed in 2641.7 ms
2024-02-21 15:20:29.405 +01:00 [INF] Time by mono laravel completed in 2647.1 ms
2024-02-21 15:20:32.039 +01:00 [INF] Time by mono LARAVEL completed in 2633.5 ms
2024-02-21 15:20:34.702 +01:00 [INF] Time by mono beta completed in 2662.6 ms
2024-02-21 15:20:37.373 +01:00 [INF] Time by mono meta completed in 2671.4 ms
2024-02-21 15:20:40.003 +01:00 [INF] Time by mono META completed in 2629.9 ms
2024-02-21 15:20:42.636 +01:00 [INF] Time by mono express-ejs-layouts completed in 2632.6 ms
2024-02-21 15:20:45.276 +01:00 [INF] Time by mono accepts completed in 2640.0 ms
2024-02-21 15:20:47.910 +01:00 [INF] Time by mono mime-db completed in 2633.9 ms
2024-02-21 15:20:50.561 +01:00 [INF] Time by mono mime-DB completed in 2651.3 ms
2024-02-21 15:20:53.215 +01:00 [INF] Time by mono iconv-lite completed in 2654.0 ms
2024-02-21 15:20:55.853 +01:00 [INF] Time by mono safer-buffer completed in 2637.8 ms
2024-02-21 15:20:58.512 +01:00 [INF] Time by mono raw-body completed in 2658.4 ms
2024-02-21 15:21:01.158 +01:00 [INF] Time by mono depd completed in 2646.4 ms
2024-02-21 15:21:03.821 +01:00 [INF] Time by mono finalhandler completed in 2662.8 ms
2024-02-21 15:21:06.494 +01:00 [INF] Time by mono on-finished completed in 2672.2 ms
2024-02-21 15:21:09.147 +01:00 [INF] Time by mono ipaddr.js completed in 2653.3 ms
2024-02-21 15:21:11.796 +01:00 [INF] Time by mono encodeurl completed in 2649.0 ms
2024-02-21 15:21:34.070 +01:00 [INF] Time by pipe completed in 22273.4 ms
```
Durchschnitt Mono: 2686,54ms <br>
Laufzeit der Pipe: 22273,4ms <br>
Gesamt Mono: 94028,9ms <br>
Faktor: 4,2215782053

### Durchgang 4 von 10
```log
2024-02-21 15:22:21.048 +01:00 [INF] Time by mono LiteDB completed in 3895.0 ms
2024-02-21 15:22:23.724 +01:00 [INF] Time by mono Newtonsoft completed in 2665.8 ms
2024-02-21 15:22:26.383 +01:00 [INF] Time by mono NewtonSoft completed in 2659.2 ms
2024-02-21 15:22:29.042 +01:00 [INF] Time by mono Crowd completed in 2659.2 ms
2024-02-21 15:22:31.704 +01:00 [INF] Time by mono Atlassian completed in 2661.8 ms
2024-02-21 15:22:34.351 +01:00 [INF] Time by mono Debian completed in 2646.3 ms
2024-02-21 15:22:37.001 +01:00 [INF] Time by mono Ubuntu completed in 2650.6 ms
2024-02-21 15:22:39.649 +01:00 [INF] Time by mono Arc42 completed in 2647.3 ms
2024-02-21 15:22:42.313 +01:00 [INF] Time by mono arc42 completed in 2664.2 ms
2024-02-21 15:22:44.961 +01:00 [INF] Time by mono cookie completed in 2647.3 ms
2024-02-21 15:22:47.607 +01:00 [INF] Time by mono mongoDb completed in 2646.0 ms
2024-02-21 15:22:50.245 +01:00 [INF] Time by mono mongoDB completed in 2638.4 ms
2024-02-21 15:22:52.904 +01:00 [INF] Time by mono mongodb completed in 2658.5 ms
2024-02-21 15:22:55.567 +01:00 [INF] Time by mono parser completed in 2662.9 ms
2024-02-21 15:22:58.203 +01:00 [INF] Time by mono LiteDb completed in 2635.9 ms
2024-02-21 15:23:00.883 +01:00 [INF] Time by mono php completed in 2680.5 ms
2024-02-21 15:23:03.545 +01:00 [INF] Time by mono PHP completed in 2661.8 ms
2024-02-21 15:23:06.229 +01:00 [INF] Time by mono Laravel completed in 2683.5 ms
2024-02-21 15:23:08.891 +01:00 [INF] Time by mono laravel completed in 2662.3 ms
2024-02-21 15:23:11.541 +01:00 [INF] Time by mono LARAVEL completed in 2649.9 ms
2024-02-21 15:23:14.208 +01:00 [INF] Time by mono beta completed in 2667.3 ms
2024-02-21 15:23:16.867 +01:00 [INF] Time by mono meta completed in 2658.4 ms
2024-02-21 15:23:19.517 +01:00 [INF] Time by mono META completed in 2649.8 ms
2024-02-21 15:23:22.180 +01:00 [INF] Time by mono express-ejs-layouts completed in 2662.6 ms
2024-02-21 15:23:24.845 +01:00 [INF] Time by mono accepts completed in 2665.6 ms
2024-02-21 15:23:27.506 +01:00 [INF] Time by mono mime-db completed in 2660.5 ms
2024-02-21 15:23:30.170 +01:00 [INF] Time by mono mime-DB completed in 2664.4 ms
2024-02-21 15:23:32.847 +01:00 [INF] Time by mono iconv-lite completed in 2676.4 ms
2024-02-21 15:23:35.501 +01:00 [INF] Time by mono safer-buffer completed in 2654.0 ms
2024-02-21 15:23:38.170 +01:00 [INF] Time by mono raw-body completed in 2669.3 ms
2024-02-21 15:23:40.840 +01:00 [INF] Time by mono depd completed in 2669.0 ms
2024-02-21 15:23:43.508 +01:00 [INF] Time by mono finalhandler completed in 2668.1 ms
2024-02-21 15:23:46.174 +01:00 [INF] Time by mono on-finished completed in 2665.5 ms
2024-02-21 15:23:48.837 +01:00 [INF] Time by mono ipaddr.js completed in 2662.7 ms
2024-02-21 15:23:51.494 +01:00 [INF] Time by mono encodeurl completed in 2657.5 ms
2024-02-21 15:24:13.535 +01:00 [INF] Time by pipe completed in 22041.2 ms
```
Durchschnitt Mono: 2695,071429ms <br>
Laufzeit der Pipe: 22041,2ms <br>
Gesamt Mono: 94327,5ms <br>
Faktor: 4,2795991143

### Durchgang 5 von 10
```log
2024-02-21 15:25:42.913 +01:00 [INF] Time by mono LiteDB completed in 4195.1 ms
2024-02-21 15:25:45.595 +01:00 [INF] Time by mono Newtonsoft completed in 2671.8 ms
2024-02-21 15:25:48.273 +01:00 [INF] Time by mono NewtonSoft completed in 2678.1 ms
2024-02-21 15:25:50.960 +01:00 [INF] Time by mono Crowd completed in 2687.0 ms
2024-02-21 15:25:53.630 +01:00 [INF] Time by mono Atlassian completed in 2669.7 ms
2024-02-21 15:25:56.287 +01:00 [INF] Time by mono Debian completed in 2657.2 ms
2024-02-21 15:25:58.963 +01:00 [INF] Time by mono Ubuntu completed in 2676.2 ms
2024-02-21 15:26:01.609 +01:00 [INF] Time by mono Arc42 completed in 2645.2 ms
2024-02-21 15:26:04.272 +01:00 [INF] Time by mono arc42 completed in 2663.0 ms
2024-02-21 15:26:06.950 +01:00 [INF] Time by mono cookie completed in 2678.2 ms
2024-02-21 15:26:09.635 +01:00 [INF] Time by mono mongoDb completed in 2685.4 ms
2024-02-21 15:26:12.301 +01:00 [INF] Time by mono mongoDB completed in 2665.6 ms
2024-02-21 15:26:14.981 +01:00 [INF] Time by mono mongodb completed in 2679.3 ms
2024-02-21 15:26:17.668 +01:00 [INF] Time by mono parser completed in 2686.9 ms
2024-02-21 15:26:20.346 +01:00 [INF] Time by mono LiteDb completed in 2678.2 ms
2024-02-21 15:26:23.037 +01:00 [INF] Time by mono php completed in 2690.9 ms
2024-02-21 15:26:25.715 +01:00 [INF] Time by mono PHP completed in 2678.4 ms
2024-02-21 15:26:28.384 +01:00 [INF] Time by mono Laravel completed in 2668.6 ms
2024-02-21 15:26:31.053 +01:00 [INF] Time by mono laravel completed in 2668.6 ms
2024-02-21 15:26:33.718 +01:00 [INF] Time by mono LARAVEL completed in 2664.8 ms
2024-02-21 15:26:36.372 +01:00 [INF] Time by mono beta completed in 2654.2 ms
2024-02-21 15:26:39.029 +01:00 [INF] Time by mono meta completed in 2656.4 ms
2024-02-21 15:26:41.671 +01:00 [INF] Time by mono META completed in 2642.4 ms
2024-02-21 15:26:44.336 +01:00 [INF] Time by mono express-ejs-layouts completed in 2664.9 ms
2024-02-21 15:26:47.001 +01:00 [INF] Time by mono accepts completed in 2664.4 ms
2024-02-21 15:26:49.651 +01:00 [INF] Time by mono mime-db completed in 2649.9 ms
2024-02-21 15:26:52.303 +01:00 [INF] Time by mono mime-DB completed in 2652.8 ms
2024-02-21 15:26:54.960 +01:00 [INF] Time by mono iconv-lite completed in 2656.4 ms
2024-02-21 15:26:57.630 +01:00 [INF] Time by mono safer-buffer completed in 2670.2 ms
2024-02-21 15:27:00.296 +01:00 [INF] Time by mono raw-body completed in 2665.4 ms
2024-02-21 15:27:02.963 +01:00 [INF] Time by mono depd completed in 2667.3 ms
2024-02-21 15:27:05.638 +01:00 [INF] Time by mono finalhandler completed in 2675.1 ms
2024-02-21 15:27:08.315 +01:00 [INF] Time by mono on-finished completed in 2676.2 ms
2024-02-21 15:27:10.992 +01:00 [INF] Time by mono ipaddr.js completed in 2677.3 ms
2024-02-21 15:27:13.679 +01:00 [INF] Time by mono encodeurl completed in 2686.5 ms
2024-02-21 15:27:35.944 +01:00 [INF] Time by pipe completed in 22265.6 ms
```
Durchschnitt Mono: 2712,788571ms <br>
Laufzeit der Pipe: 22265,6ms <br>
Gesamt Mono: 94947,6ms <br>
Faktor: 4,264318051

### Durchgang 6 von 10
```log
2024-02-21 15:28:48.481 +01:00 [INF] Time by mono LiteDB completed in 3908.8 ms
2024-02-21 15:28:51.150 +01:00 [INF] Time by mono Newtonsoft completed in 2658.6 ms
2024-02-21 15:28:53.815 +01:00 [INF] Time by mono NewtonSoft completed in 2665.2 ms
2024-02-21 15:28:56.486 +01:00 [INF] Time by mono Crowd completed in 2670.9 ms
2024-02-21 15:28:59.145 +01:00 [INF] Time by mono Atlassian completed in 2658.7 ms
2024-02-21 15:29:01.815 +01:00 [INF] Time by mono Debian completed in 2670.3 ms
2024-02-21 15:29:04.488 +01:00 [INF] Time by mono Ubuntu completed in 2673.0 ms
2024-02-21 15:29:07.169 +01:00 [INF] Time by mono Arc42 completed in 2680.6 ms
2024-02-21 15:29:09.835 +01:00 [INF] Time by mono arc42 completed in 2665.9 ms
2024-02-21 15:29:12.506 +01:00 [INF] Time by mono cookie completed in 2671.1 ms
2024-02-21 15:29:15.181 +01:00 [INF] Time by mono mongoDb completed in 2674.8 ms
2024-02-21 15:29:17.867 +01:00 [INF] Time by mono mongoDB completed in 2685.6 ms
2024-02-21 15:29:20.551 +01:00 [INF] Time by mono mongodb completed in 2683.9 ms
2024-02-21 15:29:23.228 +01:00 [INF] Time by mono parser completed in 2676.8 ms
2024-02-21 15:29:25.903 +01:00 [INF] Time by mono LiteDb completed in 2675.1 ms
2024-02-21 15:29:28.568 +01:00 [INF] Time by mono php completed in 2665.1 ms
2024-02-21 15:29:31.247 +01:00 [INF] Time by mono PHP completed in 2679.0 ms
2024-02-21 15:29:33.909 +01:00 [INF] Time by mono Laravel completed in 2662.0 ms
2024-02-21 15:29:36.587 +01:00 [INF] Time by mono laravel completed in 2677.4 ms
2024-02-21 15:29:39.239 +01:00 [INF] Time by mono LARAVEL completed in 2652.3 ms
2024-02-21 15:29:41.900 +01:00 [INF] Time by mono beta completed in 2660.6 ms
2024-02-21 15:29:44.557 +01:00 [INF] Time by mono meta completed in 2657.5 ms
2024-02-21 15:29:47.206 +01:00 [INF] Time by mono META completed in 2648.4 ms
2024-02-21 15:29:49.862 +01:00 [INF] Time by mono express-ejs-layouts completed in 2655.7 ms
2024-02-21 15:29:52.522 +01:00 [INF] Time by mono accepts completed in 2659.9 ms
2024-02-21 15:29:55.186 +01:00 [INF] Time by mono mime-db completed in 2663.8 ms
2024-02-21 15:29:57.835 +01:00 [INF] Time by mono mime-DB completed in 2649.1 ms
2024-02-21 15:30:00.492 +01:00 [INF] Time by mono iconv-lite completed in 2657.1 ms
2024-02-21 15:30:03.164 +01:00 [INF] Time by mono safer-buffer completed in 2672.2 ms
2024-02-21 15:30:05.832 +01:00 [INF] Time by mono raw-body completed in 2667.5 ms
2024-02-21 15:30:08.498 +01:00 [INF] Time by mono depd completed in 2665.8 ms
2024-02-21 15:30:11.166 +01:00 [INF] Time by mono finalhandler completed in 2667.8 ms
2024-02-21 15:30:13.831 +01:00 [INF] Time by mono on-finished completed in 2664.5 ms
2024-02-21 15:30:16.480 +01:00 [INF] Time by mono ipaddr.js completed in 2649.5 ms
2024-02-21 15:30:19.148 +01:00 [INF] Time by mono encodeurl completed in 2667.3 ms
2024-02-21 15:30:41.173 +01:00 [INF] Time by pipe completed in 22025.6 ms
```
Durchschnitt Mono: 2701,765714ms <br>
Laufzeit der Pipe: 22025,6ms <br>
Gesamt Mono: 94561,8ms <br>
Faktor: 4,2932678338

### Durchgang 7 von 10
```log
2024-02-21 15:35:57.965 +01:00 [INF] Time by mono LiteDB completed in 3805.9 ms
2024-02-21 15:36:00.640 +01:00 [INF] Time by mono Newtonsoft completed in 2665.7 ms
2024-02-21 15:36:03.329 +01:00 [INF] Time by mono NewtonSoft completed in 2687.9 ms
2024-02-21 15:36:06.027 +01:00 [INF] Time by mono Crowd completed in 2698.6 ms
2024-02-21 15:36:08.703 +01:00 [INF] Time by mono Atlassian completed in 2675.4 ms
2024-02-21 15:36:11.373 +01:00 [INF] Time by mono Debian completed in 2670.5 ms
2024-02-21 15:36:14.046 +01:00 [INF] Time by mono Ubuntu completed in 2672.7 ms
2024-02-21 15:36:16.727 +01:00 [INF] Time by mono Arc42 completed in 2681.3 ms
2024-02-21 15:36:19.410 +01:00 [INF] Time by mono arc42 completed in 2682.9 ms
2024-02-21 15:36:22.095 +01:00 [INF] Time by mono cookie completed in 2684.7 ms
2024-02-21 15:36:24.773 +01:00 [INF] Time by mono mongoDb completed in 2677.2 ms
2024-02-21 15:36:27.442 +01:00 [INF] Time by mono mongoDB completed in 2669.8 ms
2024-02-21 15:36:30.123 +01:00 [INF] Time by mono mongodb completed in 2680.6 ms
2024-02-21 15:36:32.799 +01:00 [INF] Time by mono parser completed in 2675.7 ms
2024-02-21 15:36:35.460 +01:00 [INF] Time by mono LiteDb completed in 2660.7 ms
2024-02-21 15:36:38.121 +01:00 [INF] Time by mono php completed in 2661.2 ms
2024-02-21 15:36:40.823 +01:00 [INF] Time by mono PHP completed in 2702.3 ms
2024-02-21 15:36:43.482 +01:00 [INF] Time by mono Laravel completed in 2658.7 ms
2024-02-21 15:36:46.139 +01:00 [INF] Time by mono laravel completed in 2656.8 ms
2024-02-21 15:36:48.793 +01:00 [INF] Time by mono LARAVEL completed in 2654.0 ms
2024-02-21 15:36:51.473 +01:00 [INF] Time by mono beta completed in 2679.7 ms
2024-02-21 15:36:54.144 +01:00 [INF] Time by mono meta completed in 2670.9 ms
2024-02-21 15:36:56.788 +01:00 [INF] Time by mono META completed in 2643.9 ms
2024-02-21 15:36:59.466 +01:00 [INF] Time by mono express-ejs-layouts completed in 2678.0 ms
2024-02-21 15:37:02.138 +01:00 [INF] Time by mono accepts completed in 2672.1 ms
2024-02-21 15:37:04.807 +01:00 [INF] Time by mono mime-db completed in 2669.0 ms
2024-02-21 15:37:07.480 +01:00 [INF] Time by mono mime-DB completed in 2672.6 ms
2024-02-21 15:37:10.153 +01:00 [INF] Time by mono iconv-lite completed in 2672.6 ms
2024-02-21 15:37:12.843 +01:00 [INF] Time by mono safer-buffer completed in 2689.8 ms
2024-02-21 15:37:15.516 +01:00 [INF] Time by mono raw-body completed in 2672.7 ms
2024-02-21 15:37:18.176 +01:00 [INF] Time by mono depd completed in 2659.8 ms
2024-02-21 15:37:20.851 +01:00 [INF] Time by mono finalhandler completed in 2675.1 ms
2024-02-21 15:37:23.522 +01:00 [INF] Time by mono on-finished completed in 2671.4 ms
2024-02-21 15:37:26.198 +01:00 [INF] Time by mono ipaddr.js completed in 2675.3 ms
2024-02-21 15:37:28.872 +01:00 [INF] Time by mono encodeurl completed in 2673.9 ms
2024-02-21 15:37:50.909 +01:00 [INF] Time by pipe completed in 22037.0 ms
```
Durchschnitt Mono: 2705,697143ms <br>
Laufzeit der Pipe: 22037,0ms <br>
Gesamt Mono: 94699,4ms <br>
Faktor: 4,2972909198

### Durchgang 8 von 10
```log
2024-02-21 15:38:59.564 +01:00 [INF] Time by mono LiteDB completed in 3914.2 ms
2024-02-21 15:39:02.277 +01:00 [INF] Time by mono Newtonsoft completed in 2703.2 ms
2024-02-21 15:39:04.995 +01:00 [INF] Time by mono NewtonSoft completed in 2717.7 ms
2024-02-21 15:39:07.709 +01:00 [INF] Time by mono Crowd completed in 2714.1 ms
2024-02-21 15:39:10.402 +01:00 [INF] Time by mono Atlassian completed in 2693.0 ms
2024-02-21 15:39:13.115 +01:00 [INF] Time by mono Debian completed in 2712.6 ms
2024-02-21 15:39:15.830 +01:00 [INF] Time by mono Ubuntu completed in 2714.6 ms
2024-02-21 15:39:18.549 +01:00 [INF] Time by mono Arc42 completed in 2719.5 ms
2024-02-21 15:39:21.277 +01:00 [INF] Time by mono arc42 completed in 2727.6 ms
2024-02-21 15:39:23.993 +01:00 [INF] Time by mono cookie completed in 2715.4 ms
2024-02-21 15:39:26.713 +01:00 [INF] Time by mono mongoDb completed in 2720.5 ms
2024-02-21 15:39:29.431 +01:00 [INF] Time by mono mongoDB completed in 2718.2 ms
2024-02-21 15:39:32.134 +01:00 [INF] Time by mono mongodb completed in 2702.6 ms
2024-02-21 15:39:34.846 +01:00 [INF] Time by mono parser completed in 2711.8 ms
2024-02-21 15:39:37.560 +01:00 [INF] Time by mono LiteDb completed in 2713.6 ms
2024-02-21 15:39:40.275 +01:00 [INF] Time by mono php completed in 2715.2 ms
2024-02-21 15:39:42.977 +01:00 [INF] Time by mono PHP completed in 2702.1 ms
2024-02-21 15:39:45.698 +01:00 [INF] Time by mono Laravel completed in 2720.3 ms
2024-02-21 15:39:48.420 +01:00 [INF] Time by mono laravel completed in 2722.3 ms
2024-02-21 15:39:51.136 +01:00 [INF] Time by mono LARAVEL completed in 2716.2 ms
2024-02-21 15:39:53.830 +01:00 [INF] Time by mono beta completed in 2693.8 ms
2024-02-21 15:39:56.548 +01:00 [INF] Time by mono meta completed in 2717.8 ms
2024-02-21 15:39:59.253 +01:00 [INF] Time by mono META completed in 2704.6 ms
2024-02-21 15:40:01.969 +01:00 [INF] Time by mono express-ejs-layouts completed in 2716.0 ms
2024-02-21 15:40:04.674 +01:00 [INF] Time by mono accepts completed in 2705.0 ms
2024-02-21 15:40:07.394 +01:00 [INF] Time by mono mime-db completed in 2719.6 ms
2024-02-21 15:40:10.116 +01:00 [INF] Time by mono mime-DB completed in 2722.5 ms
2024-02-21 15:40:12.816 +01:00 [INF] Time by mono iconv-lite completed in 2699.7 ms
2024-02-21 15:40:15.530 +01:00 [INF] Time by mono safer-buffer completed in 2714.0 ms
2024-02-21 15:40:18.249 +01:00 [INF] Time by mono raw-body completed in 2719.2 ms
2024-02-21 15:40:20.964 +01:00 [INF] Time by mono depd completed in 2714.5 ms
2024-02-21 15:40:23.681 +01:00 [INF] Time by mono finalhandler completed in 2717.1 ms
2024-02-21 15:40:26.409 +01:00 [INF] Time by mono on-finished completed in 2727.4 ms
2024-02-21 15:40:29.108 +01:00 [INF] Time by mono ipaddr.js completed in 2698.8 ms
2024-02-21 15:40:31.801 +01:00 [INF] Time by mono encodeurl completed in 2693.3 ms
2024-02-21 15:40:54.221 +01:00 [INF] Time by pipe completed in 22419.6 ms
```
Durchschnitt Mono: 2746,8ms <br>
Laufzeit der Pipe: 22419,6ms <br>
Gesamt Mono: 96138ms <br>
Faktor: 4,28812289

### Durchgang 9 von 10
```log
2024-02-21 15:42:36.944 +01:00 [INF] Time by mono LiteDB completed in 4029.9 ms
2024-02-21 15:42:39.619 +01:00 [INF] Time by mono Newtonsoft completed in 2665.9 ms
2024-02-21 15:42:42.278 +01:00 [INF] Time by mono NewtonSoft completed in 2658.3 ms
2024-02-21 15:42:44.956 +01:00 [INF] Time by mono Crowd completed in 2677.8 ms
2024-02-21 15:42:47.609 +01:00 [INF] Time by mono Atlassian completed in 2653.4 ms
2024-02-21 15:42:50.290 +01:00 [INF] Time by mono Debian completed in 2681.1 ms
2024-02-21 15:42:52.959 +01:00 [INF] Time by mono Ubuntu completed in 2668.2 ms
2024-02-21 15:42:55.629 +01:00 [INF] Time by mono Arc42 completed in 2670.1 ms
2024-02-21 15:42:58.302 +01:00 [INF] Time by mono arc42 completed in 2673.1 ms
2024-02-21 15:43:00.957 +01:00 [INF] Time by mono cookie completed in 2654.4 ms
2024-02-21 15:43:03.639 +01:00 [INF] Time by mono mongoDb completed in 2682.3 ms
2024-02-21 15:43:06.328 +01:00 [INF] Time by mono mongoDB completed in 2688.9 ms
2024-02-21 15:43:09.001 +01:00 [INF] Time by mono mongodb completed in 2673.4 ms
2024-02-21 15:43:11.692 +01:00 [INF] Time by mono parser completed in 2690.1 ms
2024-02-21 15:43:14.368 +01:00 [INF] Time by mono LiteDb completed in 2676.6 ms
2024-02-21 15:43:17.035 +01:00 [INF] Time by mono php completed in 2666.7 ms
2024-02-21 15:43:19.716 +01:00 [INF] Time by mono PHP completed in 2680.7 ms
2024-02-21 15:43:22.396 +01:00 [INF] Time by mono Laravel completed in 2679.6 ms
2024-02-21 15:43:25.092 +01:00 [INF] Time by mono laravel completed in 2696.4 ms
2024-02-21 15:43:27.765 +01:00 [INF] Time by mono LARAVEL completed in 2673.0 ms
2024-02-21 15:43:30.439 +01:00 [INF] Time by mono beta completed in 2673.1 ms
2024-02-21 15:43:33.106 +01:00 [INF] Time by mono meta completed in 2666.8 ms
2024-02-21 15:43:35.784 +01:00 [INF] Time by mono META completed in 2677.9 ms
2024-02-21 15:43:38.459 +01:00 [INF] Time by mono express-ejs-layouts completed in 2675.0 ms
2024-02-21 15:43:41.139 +01:00 [INF] Time by mono accepts completed in 2679.4 ms
2024-02-21 15:43:43.805 +01:00 [INF] Time by mono mime-db completed in 2666.0 ms
2024-02-21 15:43:46.462 +01:00 [INF] Time by mono mime-DB completed in 2656.4 ms
2024-02-21 15:43:49.130 +01:00 [INF] Time by mono iconv-lite completed in 2668.2 ms
2024-02-21 15:43:51.801 +01:00 [INF] Time by mono safer-buffer completed in 2671.4 ms
2024-02-21 15:43:54.465 +01:00 [INF] Time by mono raw-body completed in 2663.7 ms
2024-02-21 15:43:57.134 +01:00 [INF] Time by mono depd completed in 2668.6 ms
2024-02-21 15:43:59.811 +01:00 [INF] Time by mono finalhandler completed in 2676.7 ms
2024-02-21 15:44:02.503 +01:00 [INF] Time by mono on-finished completed in 2692.3 ms
2024-02-21 15:44:05.177 +01:00 [INF] Time by mono ipaddr.js completed in 2673.8 ms
2024-02-21 15:44:07.869 +01:00 [INF] Time by mono encodeurl completed in 2692.1 ms
2024-02-21 15:44:29.962 +01:00 [INF] Time by pipe completed in 22092.4 ms
```
Durchschnitt Mono: 2712,608571ms <br>
Laufzeit der Pipe: 22092,4ms <br>
Gesamt Mono: 94941,3ms <br>
Faktor: 4,2974642864

### Durchgang 10 von 10
```log
2024-02-21 15:45:17.426 +01:00 [INF] Time by mono LiteDB completed in 3985.9 ms
2024-02-21 15:45:20.063 +01:00 [INF] Time by mono Newtonsoft completed in 2627.1 ms
2024-02-21 15:45:22.688 +01:00 [INF] Time by mono NewtonSoft completed in 2624.8 ms
2024-02-21 15:45:25.333 +01:00 [INF] Time by mono Crowd completed in 2644.6 ms
2024-02-21 15:45:27.961 +01:00 [INF] Time by mono Atlassian completed in 2627.8 ms
2024-02-21 15:45:30.593 +01:00 [INF] Time by mono Debian completed in 2632.2 ms
2024-02-21 15:45:33.222 +01:00 [INF] Time by mono Ubuntu completed in 2628.7 ms
2024-02-21 15:45:35.856 +01:00 [INF] Time by mono Arc42 completed in 2634.3 ms
2024-02-21 15:45:38.462 +01:00 [INF] Time by mono arc42 completed in 2605.6 ms
2024-02-21 15:45:41.080 +01:00 [INF] Time by mono cookie completed in 2618.4 ms
2024-02-21 15:45:43.698 +01:00 [INF] Time by mono mongoDb completed in 2617.8 ms
2024-02-21 15:45:46.325 +01:00 [INF] Time by mono mongoDB completed in 2626.6 ms
2024-02-21 15:45:48.949 +01:00 [INF] Time by mono mongodb completed in 2623.7 ms
2024-02-21 15:45:51.559 +01:00 [INF] Time by mono parser completed in 2610.7 ms
2024-02-21 15:45:54.214 +01:00 [INF] Time by mono LiteDb completed in 2654.7 ms
2024-02-21 15:45:56.852 +01:00 [INF] Time by mono php completed in 2637.5 ms
2024-02-21 15:45:59.475 +01:00 [INF] Time by mono PHP completed in 2622.8 ms
2024-02-21 15:46:02.102 +01:00 [INF] Time by mono Laravel completed in 2626.9 ms
2024-02-21 15:46:04.732 +01:00 [INF] Time by mono laravel completed in 2629.7 ms
2024-02-21 15:46:07.361 +01:00 [INF] Time by mono LARAVEL completed in 2629.8 ms
2024-02-21 15:46:09.986 +01:00 [INF] Time by mono beta completed in 2624.7 ms
2024-02-21 15:46:12.622 +01:00 [INF] Time by mono meta completed in 2635.4 ms
2024-02-21 15:46:15.255 +01:00 [INF] Time by mono META completed in 2633.3 ms
2024-02-21 15:46:17.886 +01:00 [INF] Time by mono express-ejs-layouts completed in 2630.7 ms
2024-02-21 15:46:20.518 +01:00 [INF] Time by mono accepts completed in 2631.6 ms
2024-02-21 15:46:23.145 +01:00 [INF] Time by mono mime-db completed in 2626.9 ms
2024-02-21 15:46:25.792 +01:00 [INF] Time by mono mime-DB completed in 2646.3 ms
2024-02-21 15:46:28.419 +01:00 [INF] Time by mono iconv-lite completed in 2627.2 ms
2024-02-21 15:46:31.052 +01:00 [INF] Time by mono safer-buffer completed in 2633.2 ms
2024-02-21 15:46:33.675 +01:00 [INF] Time by mono raw-body completed in 2622.8 ms
2024-02-21 15:46:36.303 +01:00 [INF] Time by mono depd completed in 2627.3 ms
2024-02-21 15:46:38.930 +01:00 [INF] Time by mono finalhandler completed in 2627.2 ms
2024-02-21 15:46:41.551 +01:00 [INF] Time by mono on-finished completed in 2620.6 ms
2024-02-21 15:46:44.175 +01:00 [INF] Time by mono ipaddr.js completed in 2624.0 ms
2024-02-21 15:46:46.817 +01:00 [INF] Time by mono encodeurl completed in 2641.9 ms
2024-02-21 15:47:08.654 +01:00 [INF] Time by pipe completed in 21836.9 ms
```
Durchschnitt Mono: 2667,505714ms <br>
Laufzeit der Pipe: 21836,9ms <br>
Gesamt Mono: 93362,7ms <br>
Faktor: 4,2754557652

### Erkenntnisse
Die durchschnittliche Laufzeit der Mono bzw. Single-Paket Analyse dauerte: <br>
Die Gesamtlaufzeit von Mono beträgt: <br>
Die Gesamtlaufzeit von Pipe beträgt: <br>

Der Durchschnittliche Faktor (schnellere Pipe als Mono) beträgt: 4,296846569