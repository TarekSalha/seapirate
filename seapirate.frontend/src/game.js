import Phaser from 'phaser';

var config = {
  type: Phaser.AUTO,
  width: 800,
  height: 600,
  physics: {
    default: 'arcade',
    arcade: {
      gravity: { y: 0 },
    },
  },
  scene: {
    preload: preload,
    create: create,
    update: update,
  },
};

var game = new Phaser.Game(config);

function preload() {
  this.load.image('island', 'assets/island.png');  // Load assets using Webpack's file-loader
}

function create() {
  this.cameras.main.setBackgroundColor('#87CEEB');  // Light blue background
  this.add.image(400, 300, 'island');  // Add the image to the scene
}

function update() {
  // Game logic goes here
}
