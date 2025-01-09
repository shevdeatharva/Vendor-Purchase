function BaseService(controllerName, actionName, data1,Verb) {
    var url1 = '/' + controllerName + '/' + actionName;  
    console.log("url", url1);
    $.ajax({
        url: url1,
        data: JSON.stringify(data1),
        type: Verb, 
        contentType: "application/json", 
        dataType: "json",
        success: function (response) {
            if (response.success) {
                return response;
            } else {
                errorCallback(response);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
            errorCallback({ message: "An error occurred" });
        }
    });
}
