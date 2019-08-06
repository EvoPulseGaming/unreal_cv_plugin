#if defined _WIN32 || defined _WIN64
    #include <Windows.h>

    #define DLLEXPORT __declspec(dllexport)
#else
    #include <stdio.h>
#endif

#ifndef DLLEXPORT
    #define DLLEXPORT
#endif

//#include <opencv2/core.hpp>
//#include<opencv2/highgui.hpp>

DLLEXPORT void ExampleLibraryFunction()
{
	//cv::Mat frame(512, 512, CV_8UC4);
	//cv::imshow("haha", frame);
	//cv::waitKey(0);


//#if defined _WIN32 || defined _WIN64
//	MessageBox(NULL, TEXT("Hello world!"), NULL, MB_OK);
//#else
//    printf("Hello World");
//#endif
}