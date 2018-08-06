# MyProject
Assessment

# Reticle Bug Log

## Prelude

Firstly, If you don't understand the difference between CPU and GPU I would recommend this short 1 min video: 

[https://www.youtube.com/watch?v=-P28LKWTzrI](https://www.youtube.com/watch?v=-P28LKWTzrI)

To understand what was going on you first need to understand how graphics work: 

Everything that you see on digital devices is made out of triangles. This is how a square is drawn to the screen: 

![](square-e6f47295-0709-4aa2-a254-6a6fdeb59428.jpg)

It is made out of two triangles. This is how a 3D model looks: 

![](download-3c8bacae-bbad-476f-bd6d-0c3f44906b21.jpg)

To draw a triangle you specify 3 points (x, y, z) on the screen and the GPU connects the points, something like this: 

![](triangle-object-01e93b43-8143-4ee5-9a51-31f04444a34f.gif)

Since a screen is a two dimensional surface there should only be x and y co-ordinates, just like a graph paper but here in lies the problem, in a 3D scene there are multiple objects, how do you decide which triangle is in front of which:

![](OverloappingTriangles-764e49d9-8406-47ae-8dd7-a8beba8c9fd8.png)

That is why we use the z co-ordinate(called depth) to tell the GPU what triangle is in front of which (the bigger the z co-ordinate the farther away the triangle is from the user). 

This is what happens when drawing a triangle: 

1. 1. Put the three points of the red triangle on screen (x, y, z)
2. Join the dots to create a triangle
3. Then change the color of the pixels inside those dots to color the triangle to red. 
4. Then do the same for the blue triangle. 

Most GPU perform an optimization at this stage as changing the color of a pixel on screen is very computationally expensive, to reduce this overhead this is what happens: 

Now the gpu already knows that it needs to draw the blue triangle on top of the red triangle (the z-co-ordinate) it stores these values in special place in memory called the z-buffer. 

1. Before coloring the pixels the cpu checks the z-values in the buffer and says, oh the user will never see this part of the triangle as the blue triangle would be drawn over it, so i'm not going to color that part of the triangle at all saving a lot of computation power. 
2. For the blue triangle it checks the z-buffer again and says 'oh the z value is close to the user, I better make sure that I draw this' and so it draws all the pixels in the blue triangle. 

## Ghost Hunt

Our problem comes from how different GPU manufacturers store numbers differently. 

I'm gonna explain this using a cake, when we humans divide a cake in 3 parts, this is how we do it: 

![](437081-31df22ea-0ef7-4fb6-aa3b-602c9ee68b79.image2.jpg)

But if we put 1/3 in a calculator, this is the output we will get 0.3333 and it keeps going on. Unlike humans computers have no way to tell that 1/3 + 1/3 + 1/3 is basically 1, But a computer has limited memory, so it can't keep going on forever. 

Computers with low memory will output: 

![](Untitled-7548d962-6384-47fe-8e44-2d74d029a481.png)

whereas computer with more memory would output: 

![](Untitled-29707267-1c9d-4ed9-827d-345cdf2d5408.png)

So this basically means some calculations in a computer will always be error prone, so in the first case if we add 0.33 + 0.33 + 0.33 we expect the answer to be 1 but instead we get. 

![](Untitled-51e81e66-3018-4b73-be2d-0548b18a05f8.png)

but if we were to to add up 0.333333333333 three times we would get

![](Untitled-5782b7f7-5981-41f9-aa09-c915e97ad4d0.png)

There is still an error but it is too miniscule to show up in the computer with higher memory, so inherently computers are inaccurate. This is called the floating point precision of a computer. 

Now different GPU's use different size z-buffers (to store the depth values of triangles) apple uses a 16-bit buffer (more memory) and some android devices use a 8-bit buffer (less memory) while some use 16-bit buffer. 

So when the triangles(in our case our reticle and other elements on screen) are very close to each other, the gpu with higher precision can easily tell which one is on top of which. Hence it worked fine on some android devices and Apple as they use a standard size across all their devices. 

In your case the Reticle didn't show at all because having less precise values in z-buffer (due to lower memory) caused the z value to be off by 0.000001 and hence the GPU discarded the whole reticle texture as it thought the user will never see it. In Matt's case he saw a **grainy** reticle because the GPU was not sure if graphic is behind another graphic or in front and was constantly switching between them very quickly. 

Hope this answers your question, I have left out lots of details and inner workings of the GPU here please let me know if you need more details and I would be happy to explain.
