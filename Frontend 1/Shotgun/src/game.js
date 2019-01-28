class Player {
    constructor(name, shots, alive, lives) {
        this.name = '';
        this.shots = 0;
        this.alive = true;
        this.lives = 3;
    }

    load(character) {
        if (this.shots == 0) {
            appendImage(character);
            $('#aload')[0].play();
            this.shots++;

        } else if (this.shots == 1) {
            appendImage(character);
            $('#aload')[0].play();
            this.shots++;

        } else if (this.shots == 2) {
            appendImage(character);
            $('#aload')[0].play();
            this.shots++;
        }
        if (player.shots == 3) {
            $('#content').text('Quick! Use your Deadeye ' + player.name + '!');
            deadeye();

        } else
            $('#content').text(this.name + ' loaded his gun');

    };

    shoot(character) {
        $('#ashot')[0].play();
        removeImage(character);
        this.shots--;
    }

    dodge() {
        $('#adodge')[0].play();
    }
    deadeye(character) {
        $('#adeadeye')[0].play();
        removeAllImages(character);
        retry();
    }
};

$(document).ready(function () {
    $('.btn').click(function () {
        if (comp.alive == false) {
            console.log('comp died')

        } else {
            playerChoice = $(this).attr('id');
            playerAction(playerChoice)
        }

    });
});

let player = new Player();
player.name = 'Freddie'
let comp = new Player();
comp.name = 'Mr. Belvedere'

let playerChoice;
let compChoice;


function bulletHoles() {
    let bullets = ['b1', 'b2', 'b3', 'b4', 'b5', 'b6'];
    let bullet = bullets[Math.floor(Math.random() * bullets.length)];
    let element = document.getElementById(bullet);
    element.classList.remove("hidden");
    console.log(bullet);
};

function deadeye() {
    let element = document.getElementById('dead');
    element.classList.remove("hide");  

    $(".standard").addClass('hide');
}

function retry() {
    let element = document.getElementById('retry');
    element.classList.remove("hide");  
    let text = document.getElementById('win');
    text.classList.remove("hide");
    console.log(element);

    $(".standard ").addClass('hide');
    $(".deadeye ").addClass('hide');
}

// #region bullets
function appendImage(character) {
    let img = $('<img class="bullet" src="images/OD53.png">');
    img.appendTo('.' + character + '-bullets');
};

function removeImage(character) {
    $('.' + character + '-bullets > img').remove('.bullet:last-child');
};
function removeAllImages(character) {
    $('.' + character + '-bullets > img').remove('.bullet');
};
// #endregion bullets


function compMove() {
    let compChoices = ['load', 'shoot', 'dodge'];
    compChoice = compChoices[Math.floor(Math.random() * compChoices.length)];
};

function playerAction(playerChoice) {

    if (playerChoice == 'load') {
        compMove();
        comparePlayerLoad(compChoice);
        return;
    }

    if (playerChoice == 'shoot') {
        if (player.shots > 0) {
            compMove();
            comparePlayerShoot(compChoice);
            return;
        } else
            $('#content').text('You have no bullets, ' + player.name);
    }

    if (playerChoice == 'dodge') {
        compMove();
        comparePlayerDodge(compChoice);
        return;
    }
    if (playerChoice == 'dead') {
        compMove();
        comparePlayerDeadeye(compChoice);
    }

    if (playerChoice =='retry') {
        location.reload();        
    }

};

//PlayerShoot

function comparePlayerShoot(compChoice) {
    if (compChoice == 'load') {
        player.shoot('player');
        comp.load();

        $('#content').text(player.name + ' shot his opponent.');
        $('#content2').text(comp.name + ' loaded his gun.');
        comp.lives--;

        console.log('player: ' + playerChoice);
        console.log('comp: ' + compChoice);
        return;
    }
    if (compChoice == 'shoot') {
        if (comp.shots > 0) {
            comp.shoot('comp');
            $('#content2').text(comp.name + ' actually shot his opponents bullet in the air!');

            player.shoot('player');
            $('#content').text(player.name + ' shot his opponents bullet, just like Robin Hood did that one time but with an arrow.');

            console.log('player: ' + playerChoice);
            console.log('comp: ' + compChoice);
        } else
            playerAction(playerChoice);
        return;
    }
    if (compChoice == 'dodge') {
        player.shoot('player');
        comp.dodge();
        $('#content').text(player.name + ' tried to shoot his opponent.');
        $('#content2').text(comp.name + ' dodged the shot.');

        console.log('player: ' + playerChoice);
        console.log('comp: ' + compChoice);
    }
};

//PlayerDodge

function comparePlayerDodge(compChoice) {
    if (compChoice == 'load') {
        comp.load('comp');
        $('#content').text(player.name + ' is so scared so he flinched when his opponent just loaded his gun. Lame.');
        $('#content2').text(comp.name + ' loaded his gun.');
        
        console.log('player: ' + playerChoice);
        console.log('comp: ' + compChoice);
        return;
    }
    if (compChoice == 'shoot') {
        if (comp.shots > 0) {
            comp.shoot('comp');
            player.dodge();
            $('#content2').text(comp.name + ' tried to shoot his opponent.');
            $('#content').text(player.name + ' dodged the shot.');
            bulletHoles();

            console.log('player: ' + playerChoice);
            console.log('comp: ' + compChoice);

        } else
            compMove();
        console.log('player: ' + playerChoice);
        console.log('comp: ' + compChoice);
        return;

    }
    if (compChoice == 'dodge') {
        $('#content').text(player.name + ' is just dancing around.');
        $('#content2').text(comp.name + ' tries to look cool.');

        console.log('player: ' + playerChoice);
        console.log('comp: ' + compChoice);
    }

};

//PlayerLoad

function comparePlayerLoad(compChoice) {
    if (compChoice == 'load') {
        player.load('player');
        comp.load('comp');
        $('#content2').text(comp.name + ' loaded his gun.');

        console.log('player: ' + playerChoice);
        console.log('comp: ' + compChoice);
        return;
    }
    if (compChoice == 'dodge') {
        player.load('player');
        $('#content2').text(comp.name + ' dodged');
        console.log('player: ' + playerChoice);
        console.log('comp: ' + compChoice);

        return;
    }
    if (compChoice == 'shoot') {
        if (comp.shots > 0) {
            comp.shoot('comp');
            bulletHoles();
            $('#content2').text(comp.name + ' shot his opponent.');
            console.log('player: ' + playerChoice);
            console.log('comp: ' + compChoice);

            player.load('player');
            player.lives--;

        } else {
            $('#content2').text('You have no bullets, ' + comp.name);
            console.log('waowawiva ' + compChoice)
            player.load('player');
            console.log('player: ' + playerChoice)
        }
    };
};

//PlayerDeadeye

function comparePlayerDeadeye(compChoice) {
    if (compChoice == 'load') {
        player.deadeye('player');
        $('#content').text(player.name + ' killed his opponent. NICE!');
        $('#content2').text(comp.name + " tried to load his gun. But that's not possible when you're DEAD! ");
        console.log('player: ' + playerChoice);
        console.log('comp: ' + compChoice);
        return;
    }
    if (compChoice == 'dodge') {
        player.deadeye('player');
        $('#content').text(player.name + ' killed his opponent. Good job Neo.');
        $('#content2').text(comp.name + " comon. You can't dodge when someone says \"Dodge this\".");
        console.log('player: ' + playerChoice);
        console.log('comp: ' + compChoice);

        return;
    }
    if (compChoice == 'shoot') {
        player.deadeye('player');
        $('#content').text(player.name + ' oblitirated his opponent! You were too fast for your opponent');
        $('#content2').text("Nice try " + comp.name + ", but you're already dead.");
        console.log('player: ' + playerChoice);
        console.log('comp: ' + compChoice);
    }

};

// Load against load: Both players get a shot
// Load against block: The player who loads gets a shot
// Block to block: Nothing happens
// Shoot against block: The player who shoot loses a shot
// Shoot against Shoot: Both players loses a shot
// Shoot against Load: The player who shoot wins the game