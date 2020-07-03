$(function (){


/*
    $(".show-fixed .links li a").on("click",function(){
        $(".flex-navebar").removeClass("show-fixed");
    });

*/
    $(window).scroll(function(){
        var myScroll = $(window).scrollTop();

        if(myScroll > 40)
        {
            $(".navbar").addClass("scroll");
        }
        else
        {
            $(".navbar").removeClass("scroll");
        }
    });

    // TOGGLE MENU 
    $(".togle").on("click",function(){
        
        $(this).toggleClass('show');
        
        $("#fixed-navbar").toggleClass("show-menu");

       
    });

    //TOGGLE LINKE CLOSE 

    $("#fixed-navbar a").on("click",function(){
        $("#toggle").removeClass("show");
        $("#fixed-navbar").removeClass("show-menu");
    });

    


    $("#links li a" ).on("click",function(){
        $(this).addClass("active").parent().siblings().find('a').removeClass("active");
    });


    $(".tewntytewnty-contianer").twentytwenty();


    // start video 

    $("#video-icon").on("click",function(){
        $(".video iframe").addClass("show");
        $("#exit").addClass("view");
        console.log("ahmed");

    });
    $("#exit").on("click",function(){
        $(".video iframe").removeClass("show");
        $("#exit").removeClass("view");
        $(".video .content-video iframe").attr("src","https://www.youtube.com/embed/9qVNFqCvhU8");
    });



// fixed video 

    $("#show-video").on("click",function(){
        $("#fixed-video").fadeIn();
        //$("#fixed-video").addClass("flex-show");

        /*if($(".fixed-video").hasClass("flex-show"))
        {
            $(this).on("click",function(){
                $("#fixed-video").fadeOut();
            });
        }*/
    });
    $("#fixed-video").on("click",function(){
        $(".fixed-video").fadeOut();
        $("#fixed-video iframe").attr("src","https://www.youtube.com/embed/9Pb1XxOqpYA")
        //$("#fixed-video").removeClass("flex-show");
    });



    $("#fixed _video").on("click",function(){
        $(this).fadeOut(400);
        console.log("ahmed")
    });




});