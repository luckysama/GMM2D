import os
from plyfile import PlyData
import matplotlib.pyplot as plt


scans = 10
z_levels = 10
epsilon = 0.004


def main():
    for scan_id in range(scans):
        z_height = 0
        scan_name = 'scene000' + str(scan_id) + '_00'
        print('Reading ' + scan_name + '_vh_clean.ply file...')
        ply_data = PlyData.read('./3d_data/scans/' + str(scan_name) + '/' + scan_name + '_vh_clean.ply')
        print('Done!')

        z = ply_data['vertex']['z']
        z_max = max(z)
        z_diff = z_max/z_levels
        for height in range(z_levels-1):
            z_height += z_diff
            upper_bound = z_height + epsilon
            lower_bound = z_height - epsilon
            x = []
            y = []

            print('Processing ' + scan_name + '_vh_clean.ply at height=', z_height, 'and range +-', epsilon)
            for point in ply_data.elements[0].data:
                if lower_bound <= point[2] <= upper_bound:
                    x.append(point[0])
                    y.append(point[1])

            print('Number of points:', len(x))
            plt.scatter(x, y)
            plt.show()
            save = input("Press Y/y to save ")
            if save == 'y' or save == 'Y':
                filename = './2d_data/' + str(scan_name) + '/' + str(z_height) + '_' + str(epsilon) + '.txt'
                try:
                    f = open(filename, 'w')
                except FileNotFoundError:
                    os.mkdir('./2d_data/' + str(scan_name))
                    f = open(filename, 'w')
                for point in range(len(x)):
                    line = str(x[point]) + ' ' + str(y[point])
                    f.write(line + os.linesep)
                f.close()


if __name__ == '__main__':
    main()
