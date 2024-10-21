# Purpose
Optimise textures \
Currently optimizes only png textures using pngquant

# How To
## By commande line
TextureOptimizer.exe [Target1] [Target2]  [TargetN] \
There can be any number of target \
Target can be a file path or a directory path

### Valid file path as Target
If the file is a png it is optimized (lossless) with [pngquant](https://pngquant.org/)

### Valid directory path as Target
Any png file recursively found in the directory is optimized (lossless) with [pngquant](https://pngquant.org/)

## By drag and drop
You can drag and drop any file or directory on TextureOptimizer.exe \
It behaves the same as by command line with target being the valid path of the dropped file or directory

## By double click
It behaves the same by command line with target being the executable directory path
