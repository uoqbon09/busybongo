module.exports = function (grunt) {
    'use strict';
    var mixIn = require('mout/object/mixIn');
    var requireConfig = {
        baseUrl: 'app/',
        paths: {
            'jquery': '../Scripts/jquery-2.1.3',
            'knockout': '../Scripts/knockout-3.3.0',
            'text': '../Scripts/text',
            'durandal': '../Scripts/durandal',
            'plugins': '../Scripts/durandal/plugins',
            'transitions': '../Scripts/durandal/transitions'
        }
    };
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        durandal: {
            main: {
                src: ['app/**/*.*', 'Scripts/durandal/**/*.js'],
                options: {
                    name: '../Scripts/almond-custom',
                    baseUrl: requireConfig.baseUrl,
                    mainPath: 'app/main',
                    paths: mixIn({}, requireConfig.paths, { 'almond': '../Scripts/almond-custom.js' }),
                    exclude: [],
                    optimize: 'none',
                    out: 'build/app/main.js'
                }
            }
        },
        uglify: {
            build: {
                src: 'build/app/main.js',
                dest: 'build/app/main-built.js'
            }
        }
    });
    grunt.loadNpmTasks('grunt-durandal');
    grunt.loadNpmTasks('grunt-contrib-uglify');    
    grunt.registerTask('build', ['durandal:main','uglify']);
};