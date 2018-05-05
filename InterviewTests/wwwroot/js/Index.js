﻿$(document).ready(function () {

     $("#AddQuestionButton").on("click", function (ev) {
        //HideAllExcept("#TransactionWaitPlease");
        //$.post("http://localhost:50462/Home/TransactionCheck",
        //$.post("https://localhost:44330/Home/TransactionCheck",
        let path = $("#AjaxHiddenPath").val();
        $.post(path,
            {
                question: $("#QuestionInput").val(),
                answer: $("#AnswerInput").val()
            },
            function (data, status) {
                ShowTransactionCheckResult(data);
            });
     });
})

function ShowTransactionCheckResult(data) {

}