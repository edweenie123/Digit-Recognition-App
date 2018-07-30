# Digit-Recognition-App
A handwritten digit recognizer trained on 5000 training examples from the MNIST training set using a Neural Network

## Abstract
   The creation of this project was mainly done under the motivation of applying my newly gained skills after completing Andrew Ng’s Machine Learning course on Coursera, while also serving as a catalyst for improving my ability to generalize to new machine learning problems. This digit recognizer is made using a machine learning technique known as a neural network (feedforward variant). In essence, a neural network is simply a representation of the neurons within our human brains. In other words, we are trying to model the complex relationships between neurons (inputs=dendrites, outputs = axons).

Here is an image of a neural network:

<img src="https://user-images.githubusercontent.com/25446747/43425516-357c060a-9429-11e8-9567-46dd2fc00de6.PNG" alt="Neural Network Image" width="500" height="500">

## Neural Networks

   Each circle is called a node (or neuron) with the lines connecting them representing the complex relationship between them (formally known as “weights”). The first layer of the network is called the input layer (leftmost layer) and is where we give the network our initial inputs (image of the digit). After the input data has gone through all the hidden layers, it will reach the output layer (rightmost layer) where it should (ideally) output the correct digit in a one-hot vector. Now that I have defined the objective, you may be wondering how we will set all the individual weights to the correct values. This is through a process called “backpropagation”. Undoubtedly, backpropagation is quite a convoluted algorithm with many implementation steps but put simply, we will feed the model a bunch of training examples (with the correct outputs) and through backpropagation, the network will eventually learn the features contained within the digit. This process will require quite a lot of training examples (>1000) as well as a significant amount of computing power although modern computers can quite easily complete this task. 
## My Model
   The network architecture I am using consists of three layers with the first layer consisting of 401 nodes. To quantify the image of the digit (so that the network will be able to interpret it), I have converted my 20x20 pixel drawing board into a 20x20 matrix, where each element is either a 1 or 0 (0 if the pixel is off, 1 if the pixel is on). Then, I have “unrolled” the matrix into a 400-dimensional vector so that my neural network can take it as an input. The extra node (accounting for 401 nodes, instead of 400) is due to the extra “bias” node we should always add. In a sense, this bias node sort of acts in the same way as the b term in the expression y=mx+b. The 2nd layer is made up of 25 nodes (+1 bias node) to balance both computational power and performance. The last layer (output layer) is made up of 10 nodes corresponding to each digit from 0-9. As I have mentioned before, the output layer will output its prediction through a one-hot vector. Note: Once a node collects all the data from its receiving nodes, it will perform what is called an activation function. In my case, I have used the standard sigmoid activation function, which clamps its value to between 0 and 1. 

   I have trained my neural network using a programming environment known as Octave (basically a free version of MatLab) on 5000 training examples from the MNIST handwritten digit database. I modified the original MNIST training set to better match the format of the inputs within this app. Put simply, I have defined a threshold (I believe I used 0.3) where if the opacity of pixel surpasses the threshold, it will be rounded to 1 and vice versa (if it's below the threshold, the pixel will be rounded to 0). I believe I trained the weights with 50 iterations of backpropagation. I have then saved them in a text file (don’t hate me not using .csv) and transferred them over to Unity3D where I have implemented forward propagation using a linear algebra library called MathNet. I honestly hated using this library as it was missing many features and there wasn’t much documentation online, but I didn't have much of a choice as it was one of the only linear algebra libraries that supported C#.

Here is what my modified MNIST training set looks like:

<img src="https://user-images.githubusercontent.com/25446747/43425949-87f83a60-942a-11e8-83c7-35c106a5b6c6.png" alt="input" width="300" height="300">

Here is what the final trained weights will look like if you convert them back to image format:

<img src="https://user-images.githubusercontent.com/25446747/43426025-ccd3af16-942a-11e8-8544-c38c44b599e1.png" alt="visualizing weights" width="300" height="300">

I realize that the final results of this project were not incredibly successful as the neural network often failed to correctly predict the correct digit. Most notably, it lacks in the ability to identify 6s and 9s. I believe the largest contributor to this is a deficiency of training data. The whole MNIST training set is comprised of 60,000 training set digits (+10,000 test set examples) compared to my measly 5,000. Moreover, state of the art digit recognizers made by Google and the likes use over millions of training examples to achieve their level of accuracy. I have decided not to add more data as this project was done as a proof of concept, rather than a competitive contender in the world of recognizing handwritten digits (and cause I’m lazy). Despite this, I may lean towards improving my results in the future. If you’d like to learn more about neural networks, feel free to take Andrew Ng’s Machine Learning course on Coursera (it’s free) and take a look at 3Blue1Brown has a great YouTube series on this topic. 

...It may be a little rough around the edges, but I will always love my firstborn.





