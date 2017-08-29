var calculate = { 
    init: function () {
        
        $("#btnCalculate").click(function () {
            var isValid = true;
            var weight = $("#Weight").val();
            var height = $("#Height").val();
            var width = $("#Width").val();
            var depth = $("#Depth").val(); 
          
           
            $("#Weight, #Height, #Width, #Depth").each(function () {

                if ($.trim($(this).val()) == "" || $.trim($(this).val()) == "0") {
                    isValid = false;
                    $(this).addClass("form-control-error");

                }
                else {
                    $(this).removeClass("form-control-error");
                }
            });
            if (isValid == false) {
                e.preventDefault();
                return false;
            }
            else {
                calculate.CalculateParcel(weight, height, width, depth);
            } 
        });

        $("#Weight, #Height, #Width, #Depth").change(function () { 
            if ($.trim($(this).val()) == "" || $.trim($(this).val()) == "0") { 
                $(this).addClass("form-control-error"); 
            }
            else {
                $(this).removeClass("form-control-error");
            }
        });

        $("#btnClear").click(function () {
            $("#lblCost").text();
            $("#displayCost").hide();
        });
    },
    CalculateParcel: function (weight, height, width, depth) {
      
        var obj = {
            weight: weight,
            height: height,
            width: width,
            depth: depth
        }
        var jsonData = JSON.stringify(obj); 
        $.ajax({
            url: "/ParcelCalculation/CalculateParcel",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: jsonData,
            async: false,
            success: function (data) {
                if (data != null) {
                    $("#lblCost").text(" " + data.Price);
                    $("#displayCost").show();
                } 
            },
            error: function () {
                console.log("Error found");
            }
        });
    }
  

}