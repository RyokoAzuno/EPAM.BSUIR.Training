## <b>Task 1</b>

IIS architecture and principles:

https://docs.microsoft.com/en-us/iis/get-started/introduction-to-iis/introduction-to-iis-architecture

Home work: Create custom asp.net handler + asp.net module + simple 3 columns design (html+ css)  

CSS reading: http://htmlbook.ru/samcss

--------------------------------------------------------------------------------------------------------------
How to create image gallery in as asp.net mvc:

http://www.advancesharp.com/blog/1130/image-gallery-in-asp-net-mvc-with-multiple-file-and-size

Some details of this sample:

    PagedList  is used as a ViewModel
    Images are stored in a folder, private void SaveToFolder   -    refactor this and create SaveToDB
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
## <b>Task 2</b>

Responsive design :

Homework : Create top level navigation bar with one ( two)  breakpoints and media queries  https://www.w3schools.com/css/css_rwd_mediaqueries.asp

Home work:

Implement Slideshow widget  similar to https://www.w3schools.com/howto/howto_js_slideshow_gallery.asp

First version: 

    ASP.NET MVC project   
    Top navigation menu on the Layout page
    Slideshow widget on an Index view
    Images are stored inside an /image folder on the server
    AJAX  paging  

Second version:

    images stored in EF database on the server + AJAX 
