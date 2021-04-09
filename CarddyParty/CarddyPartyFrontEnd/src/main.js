import './css/styles.css';
import $ from 'jquery';
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './css/styles.css';
import APIReturn from './functions.js';

function getRandomInt(max) {
  return Math.floor(Math.random() * Math.floor(max));
}

$(document).ready(function () {
  // CODE FOR INDEX
  let submits = -1;
  let cardNumber = 1;
  // This is part of CycleCount
  let playerNum = 1;

  let cards = [];
  let selectedcard = -70;

  // This will display Card #2's data on Card 1 visually
  $("#getCardButton").click(function () {
    if (submits > 2) {
      submits === -1;
    }
    submits++;
    let promise2 = APIReturn.testAPI();
    promise2.then(function (response) {
      const body = JSON.parse(response);
      let grabbedCard = body[getRandomInt(9)];
      // $(`.card-${submits}`).text(grabbedCard);
      // Lots of fun stuff behind-the-scenes here
      cards.push(grabbedCard);
      console.log(`answer card is ${grabbedCard.answer}`);
      $(`#card-${submits}`).text(grabbedCard.answer);
      $(`#card-style-${submits}`).show(500);
      // cards.push(grabbedCard.cardid);
      console.log(cards);
    }, function (error) {
      $('.output').text(`There was an error processing your request: ${error}`);
      console.log(error);
    });
  });

  // This is going to be the button to fetch Prompts
  // $("#promptButton").click(function () {
  //   let promise = APIReturn.promptAPI();
  //   promise.then(function (response) {
  //     const body = JSON.parse(response);
  //     $('.prompt-window-text').text(body.description);
  //     // console.log(body);
  //   }, function (error) {
  //     $('.output').text(`There was an error processing your request: ${error}`);
  //     console.log(error);
  //   });
  // });

  // This is the function to submit the card to the database
  $("#submitButton").click(function () {
    let promise = APIReturn.submitAPI();
    promise.then(function (response) {
      const body = JSON.parse(response);
      $(`.output`).text(body.answer);
      console.log("test");
    }, function (error) {
      $('.output').text(`There was an error processing your request: ${error}`);
      console.log(error);
    });

    // DOM elements only
    // Take the given answer from the text box and pass it to the card on screen
    let answer = document.getElementById("answer").value;
    $(`#card-${cardNumber - 1}`).text(answer);
    $(`#card-style-${cardNumber}`).show(500);
    // console.log(cardNumber);
    cardNumber++;
    $("#answer").val("");

    // Hide the submit button when
    if (cardNumber > 3) {
      // $("#submitButton").hide();
      $("#submitButton").prop("disabled", true);

    }
  });

  // $("#cyclePlayer").click(function () {
  //   let answer = document.getElementById("answer").value;
  //   $("#playerId").text(answer);
  // });

  $("#cyclePlayer").click(function () {
    // alert(typeof(playerNum));
    if (playerNum > 4) {
      playerNum = 1;
    }
    $("#playerId").text(playerNum++);
  });

  // Events to happen on any mouse click
  window.addEventListener("click", function () {

    const clicked = event.target;
    const currentID = clicked.id || "No ID!";
    const coords = currentID.split("-");
    const index = parseInt(coords[1]);

    // This will stop the errors from outputting to the console
    // Additionally, it outputs to a place on the page where it will theoretically never display :)
    try {
      $(".output").text(`Chosen card is: ${cards[index].answer}`);
      $(".output").show();
      // ^ Ash changed from .cardid to .answer but this is an easy change back. Purely for user understanding.
      selectedcard = cards[index].cardId;
    }
    catch (err) {
      document.getElementById("errorOutput").innerHTML = err.message;
    }
  });

  $("#submitCard").click(function () {
    let promise3 = APIReturn.selectAPI(selectedcard);
    promise3.then(function (response) {
      const body = JSON.parse(response);
      $(`.output`).text(body.answer);
      console.log("test");
    }, function (error) {
      $('.output').text(`There was an error processing your request: ${error}`);
      console.log(error);
    });
  });

  $("#reload").click(function(){
    location.reload(); 
  });

  // CODE FOR JUDGE STUFF
  let prompt;
  let player1Score = 0;
  let player2Score = 0;
  let player3Score = 0;
  let player4Score = 0;
  $('.p1').text(` ${player1Score}`);
  $('.p2').text(` ${player2Score}`);
  $('.p3').text(` ${player3Score}`);
  $('.p4').text(` ${player4Score}`);
  $("#p1Score").click(function () {
    player1Score += 1;
    $('.p1').text(` ${player1Score}`);
  });
  $("#p2Score").click(function () {
    player2Score += 1;
    $('.p2').text(` ${player2Score}`);
  });
  $("#p3Score").click(function () {
    player3Score += 1;
    $('.p3').text(` ${player3Score}`);
  });
  $("#p4Score").click(function () {
    player4Score += 1;
    $('.p4').text(` ${player4Score}`);
  });
  $("#promptButton").click(function () {
    let promise = APIReturn.promptAPI();
    promise.then(function (response) {
      const body = JSON.parse(response);
      $('.prompt-window-text').text(body.description);
      prompt = body;
      // console.log(body);
    }, function (error) {
      $('.output').text(`There was an error processing your request: ${error}`);
      console.log(error);
    });
  });
  $("#promptButton2").click(function () {
    console.log(prompt.theme);
    let promise = APIReturn.promptAPITheme(prompt.theme);
    promise.then(function (response) {
      const body = JSON.parse(response);
      let newPrompt = body[getRandomInt(body.length)];
      $('.prompt-window-text').text(newPrompt.description);
      // console.log(body);
    }, function (error) {
      $('.output').text(`There was an error processing your request: ${error}`);
      console.log(error);
    });
  });
  $("#getthemcards").click(function () {
    let promiseSelect1 = APIReturn.grabSelect1();
    promiseSelect1.then(function (response1) {
      const selectbody = JSON.parse(response1);
      let selectCounter = 1;
      setTimeout(function(){
      for (let i = selectbody.length - 3; i <= selectbody.length; i++ )
      {
        console.log(selectbody[i].selectedcard);
        let promiseSelect2 = APIReturn.grabSelect2(selectbody[i].selectedcard);
        promiseSelect2.then(function(response2){
          const body = JSON.parse(response2);
          $('.cardtext' + selectCounter).html(body.answer);
          selectCounter ++;
        }, function (error2){
          $('.output').text(`There was an error processing your request: ${error2}`);
        console.log(error2);
        });
      }
      $('.prompt-window-text').text(body.description);
      // console.log(body);
    }, function (error1) {
      $('.output').text(`There was an error processing your request: ${error1}`);
      console.log(error1);
    });
  }, 500);
  });

  // $("#button").click(function () {
  //   let sec = $("#selectTime").val();
  //   function timer(){
  //     $("#button").hide();
  //     $("#selectTime").hide();
  //     $("#label").hide();

  //     $("#turnTimerDisplay").append(sec)
  //     var timer = setInterval(function(){
  //         document.getElementById('turnTimerDisplay').innerHTML=sec;
  //         sec--;
  //         if (sec < 0) {
  //             clearInterval(timer);
  //             $("#turnOver").show();
  //             $("#turnTimerDisplay").hide();
  //         }
  //     }, 1000);
  //   }  
  // })
  document.getElementById('turnOver').style.visibility = 'hidden';
  $("#button").click(function () {
    // function timer(){
    document.getElementById('button').style.visibility = 'hidden';
    document.getElementById('selectTime').style.visibility = 'hidden';
    document.getElementById('label').style.visibility = 'hidden';
    var sec = document.getElementById('selectTime').value;
    let turnTimerDisplay = document.getElementById('turnTimerDisplay');
    turnTimerDisplay.append(sec);
    var timer = setInterval(function () {
      document.getElementById('turnTimerDisplay').innerHTML = sec;
      sec--;
      if (sec < 0) {
        clearInterval(timer);
        document.getElementById('turnOver').style.visibility = 'visible';
        document.getElementById('turnTimerDisplay').style.visibility = 'hidden';
        document.getElementById('button').style.visibility = 'visible';
        document.getElementById('selectTime').style.visibility = 'visible';
        document.getElementById('label').style.visibility = 'visible';
      }
    }, 1000);
  });
});