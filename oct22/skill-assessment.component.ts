import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-skill-assessment',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="skill-assessment">
      <h2>Skill Assessment</h2>
      <p>Test your skills to improve your job matches!</p>
      <div *ngIf="!testStarted">
        <button (click)="startTest()" class="start-btn">Start Assessment</button>
      </div>
      <div *ngIf="testStarted && !testCompleted">
        <h3>Question {{ currentQuestionIndex + 1 }} of {{ questions.length }}</h3>
        <p>{{ currentQuestion.question }}</p>
        <div *ngFor="let option of currentQuestion.options; let i = index">
          <label>
            <input type="radio" [name]="'question'" [value]="i" [(ngModel)]="selectedAnswer">
            {{ option }}
          </label>
        </div>
        <button (click)="nextQuestion()" class="next-btn" [disabled]="selectedAnswer === null">Next</button>
      </div>
      <div *ngIf="testCompleted">
        <h3>Assessment Completed!</h3>
        <p>Your score: {{ score }} out of {{ questions.length }}</p>
        <button (click)="restartTest()" class="restart-btn">Restart Assessment</button>
      </div>
    </div>
  `,
  styles: [`
    .skill-assessment {
      max-width: 600px;
      margin: 0 auto;
      padding: 20px;
      background-color: #f9f9f9;
      border-radius: 8px;
      box-shadow: 0 2px 4px rgba(0,0,0,0.1);
    }
    h2, h3 {
      color: #1976d2;
    }
    .start-btn, .next-btn, .restart-btn {
      background-color: #4CAF50;
      color: white;
      padding: 10px 20px;
      font-size: 16px;
      border: none;
      border-radius: 5px;
      cursor: pointer;
      transition: background-color 0.3s;
      margin-top: 20px;
    }
    .start-btn:hover, .next-btn:hover, .restart-btn:hover {
      background-color: #45a049;
    }
    .next-btn:disabled {
      background-color: #cccccc;
      cursor: not-allowed;
    }
    label {
      display: block;
      margin: 10px 0;
    }
  `]
})
export class SkillAssessmentComponent implements OnInit {
  questions = [
    {
      question: "What is the primary purpose of version control systems like Git?",
      options: [
        "To make backups of code",
        "To track changes and collaborate on code",
        "To compile code faster",
        "To automatically fix bugs"
      ],
      correctAnswer: 1
    },
    {
      question: "Which of the following is NOT a JavaScript data type?",
      options: ["String", "Boolean", "Integer", "Undefined"],
      correctAnswer: 2
    },
    {
      question: "What does CSS stand for?",
      options: [
        "Computer Style Sheets",
        "Creative Style Sheets",
        "Cascading Style Sheets",
        "Colorful Style Sheets"
      ],
      correctAnswer: 2
    }
  ];

  testStarted = false;
  testCompleted = false;
  currentQuestionIndex = 0;
  selectedAnswer: number | null = null;
  score = 0;

  get currentQuestion() {
    return this.questions[this.currentQuestionIndex];
  }

  ngOnInit() {}

  startTest() {
    this.testStarted = true;
    this.testCompleted = false;
    this.currentQuestionIndex = 0;
    this.score = 0;
  }

  nextQuestion() {
    if (this.selectedAnswer === this.currentQuestion.correctAnswer) {
      this.score++;
    }
    this.currentQuestionIndex++;
    this.selectedAnswer = null;

    if (this.currentQuestionIndex >= this.questions.length) {
      this.testCompleted = true;
    }
  }

  restartTest() {
    this.startTest();
  }
}