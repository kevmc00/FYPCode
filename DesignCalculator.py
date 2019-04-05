import numpy
import matplotlib.pyplot as plt

class main:

    forces = [24.5, 49.05, 98.1]
    actuator = []
    springConstants = []
    
    for a in numpy.arange(0,0.61,0.01):
        actuator.append(a)

    for f in forces:
        temp = []
        for a in actuator:
            temp.append(f /(0.2 + a))
        springConstants.append(temp)
        temp = []

    plt.figure(1)
    plt.xlabel("Actuator position a (m)")
    plt.ylabel("Spring Constant k")
    plt.title("Actuator position vs Spring Constant for 3 Levels")

    for i in range(0,3):
        title = ("Level " + str(i + 1) + ": " + str((i + 1) * 5) + " kg")
        plt.plot(actuator,springConstants[i], label = title)

    k = 58
    plt.plot([0, 0.6], [k, k], '--', label = "Actual k")
    k = int(springConstants[0][0])
    plt.plot([0, 0.6], [k, k], '--', label = "Ideal k")
    plt.legend()
    plt.show()
    
    print("Spring Constant = " + str(k))
    for i in range(0, 3):
        level = i + 1
        klist = springConstants[i]
        for j in range(0, len(klist)):
            if klist[j] <= k + 1:
                print("For level " + str(level) + ", a = " + str(actuator[j]))
                break

