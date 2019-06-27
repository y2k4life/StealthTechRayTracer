# StealthTech Ray Tracer

This is my attempt at The Ray Tracer Challenge following this book: [The Ray Tracer Challenge - A Test-Driven Guide to Your First 3D Renderer](https://www.barnesandnoble.com/w/the-ray-tracer-challenge-jamis-buck/1127035142).

My goals are to learn Ray Tracing, math, performance & profiling, and implementing BDD with [SpecFlow](https://specflow.org/).

I want to give a shout out to [The Morning Brew](http://blog.cwa.me.uk/) for having a link to the [CodeClimber](http://codeclimber.net.nz/tags/raytracer-challenge) by Simone Chiaretta. Which was the kick off to this journey.

## Notes

**Naming Convention** For primitive objects that collide with .Net BCL will be prefixed with `Rt` (Ray Tracer). This started with `Color` and `Tuple`. Even though the BCL does not have a `Matrix` for consistency matrix will have `Rt` therefore it is  `RtMatrix`. Using `System` namespace can cause some issues.

**Tools** [CodeRush](https://www.devexpress.com/Products/CodeRush/) for refactoring and code clean. [NCrunch](https://www.ncrunch.net/) to automate running test and to provide information relating to code coverage.

## Resources

* [Linear Algebra from MIT](https://ocw.mit.edu/courses/mathematics/18-06sc-linear-algebra-fall-2011/) Quality is bad, but great videos and it is MIT need I say more. I pulled to test for Matrices from here.

## Images

![alt text](https://raw.githubusercontent.com/y2k4life/StealthTechRayTracer/master/Images/multi-lights.png "Chapter 7 & 8 With Multi-Lights")
