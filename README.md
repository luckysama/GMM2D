
# GMM2D
This repo contains the 2D implementation of Hierarchical Gaussian Mixture Model (HGMM) (see [paper](https://www.cv-foundation.org/openaccess/content_cvpr_2016/html/Eckart_Accelerated_Generative_Models_CVPR_2016_paper.html)). 

## Requirements
Visual Studio 2019 Community and .net 4.7.2

## Implementation Details
We rigorously followed the implementation details in the [paper](https://www.cv-foundation.org/openaccess/content_cvpr_2016/html/Eckart_Accelerated_Generative_Models_CVPR_2016_paper.html) using hard partition and non-parallel construction. The development process is two-fold: we started with a flat, one level implementation, then we added a hierarchical architecture that recursively generates predictions as a multi-level gaussian tree. Following topics are covered:
* Initialization
* Flat GMM
* HGMM
* Functionalities
* Future Improvements

See details in [wiki](https://github.com/luckysama/GMM2D/wiki/Implementation-Details)

## DEMO Usage
To better demonstrate the HGMM algorithm, we created a GUI for inputting parameters and visualizing the HGMM fit at each level of the hierarchy. Following topics are covered:
* Status Label
* Configuration Settings
* Menu
* Common Application Workflow
* Common Errors

See details in [wiki](https://github.com/luckysama/GMM2D/wiki/User-Guide)
