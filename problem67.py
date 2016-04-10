#!/usr/bin/python3


def find_max_path(triangle):
    row_best = [triangle[0][0]]  # stores max scores for each position in processed row
    for row in triangle[1:]:
        zero_bounded = [0] + row_best + [0]
        new_best = []
        for i in range(len(row)):
            new_best.append(max(row[i] + zero_bounded[i], row[i] + zero_bounded[i + 1]))

        row_best = new_best

    return max(row_best)


with open('p067_triangle.txt', 'r') as file:
    lines = file.readlines()
    triangle = [[int(s_num) for s_num in line.split()] for line in lines]
    print(find_max_path(triangle))
