/// <reference path="jquery/jquery-1.6.4.js" />
/// <reference path="jquery/jquery-ui-1.8.18.js" />
/// <reference path="jquery/jquery.signalR.js" />

$(function () {

    var photoTracker = $.connection.photoTracker,
    galleria = $("#galleria");

    //thumbnailsView = $("#Thumbnails");

    $.extend(photoTracker, {
        displayAlert: function () {
            alert("me");
        },
        updateSlideView: function (photoName) {
            //if ( $.connection.hub.id != connID) {
            //var photos = $("ul", sharePhotos);
            //var data = "Connection " + $.connection.hub.id + " uploaded photo '" + photoName + "'<br/>";
            //var ulList = $("ul", photos);

            //var liTag = $("<li><img src='/PhotoShare/DisplayPhoto?Filename=" + photoName + "' id='id_" + photoName + "' alt='" + photoName + "' /></li>");

            //if (thumbnailsView.html() == "No photos") {
            //thumbnailsView.append(imgTag);
            //}

            //photos.append(liTag);
            //thumbnailsView.append(imgTag);

            //ReloadSlideViewer();
            //}

            var newPhoto = "<a href='/PhotoShare/DisplayPhoto?Filename=" + photoName + ".tbn'><img src='/PhotoShare/DisplayPhoto?Filename=" + photoName + ".pho' /></a>";
            //alert(newPhoto);
            //var photos = $("a", galleria);
            //alert(photos.length);
            //var g = galleria.get(0);
            $("#galleria").data('galleria').addElement(newPhoto);
            $("#galleria").data('galleria').load();
            //$('#galleria').galleria();
            //$("#galleria").data('galleria')._run();
            //$("#galleria").data('galleria').ru
            //galleria.addElement(newPhoto);
            //galleria.insertImage(newPhoto, photos.length + 1);
        }
    });

    $.connection.hub.start(function () {
        photoTracker.hasAnyOneSharedNewPhotos()
            .done(function (data) {
                if (data != "No") {
                    //photoTracker.updateSlideView(data);
                }
            });
    });


    function SubmitPhoto(result) {
        if (result) {
            alert("Upload Successfull !!");
            photoTracker.uploadedPhoto(result);
        }
        else {
            alert("Upload Failed !!");
        }
    }

    var options = {
        target: '#UpdatePhotoDiv',
        iframe: true,
        dataType: "json",
        success: SubmitPhoto
    };

    $('#frmUploadPhoto').ajaxForm(options);

    ReloadSlideViewer();

    function ReloadSlideViewer() {


        //        var photos = $("li", sharePhotos);
        //        if (photos.length > 0) {
        //            sharePhotos.slideViewerPro({
        //                thumbs: 6,
        //                autoslide: false,
        //                asTimer: 3500,
        //                typo: true,
        //                galBorderWidth: 0,
        //                thumbsBorderOpacity: 0,
        //                buttonsTextColor: "#707070",
        //                buttonsWidth: 40,
        //                thumbsActiveBorderOpacity: 0.8,
        //                thumbsActiveBorderColor: "aqua",
        //                shuffle: true
        //            });

        //        }

    }



});