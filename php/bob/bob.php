<?php

/**
 * Optimised for readability
 *
 * The main time cost of problems with specific
 * stakeholder-defined logic requirements can be
 * making amendments in the future. Performance
 * is not limiting here.
 *
 * Class Bob
 */
class Bob
{
    /**
     * @param string $text
     * @return string
     */
    public function respondTo(string $text): string
    {
        $isQuestion = substr(rtrim($text), -1, 1) === '?';
        $isUpperCase = strtoupper($text) === $text && strtolower($text) !== $text;
        $isSilence = !strlen(preg_filter('/\s/', '', $text));

        switch (true) {
            case $isQuestion && $isUpperCase:
                return "Calm down, I know what I'm doing!";
            case $isQuestion:
                return 'Sure.';
            case $isUpperCase:
                return 'Whoa, chill out!';
            case $isSilence:
                return 'Fine. Be that way!';
            default:
                return 'Whatever.';
        }
    }
}
